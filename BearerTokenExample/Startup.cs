using System;
using System.Threading.Tasks;
using System.Web.Http;
using BearerTokenExample.BearerToken;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;

[assembly: OwinStartup(typeof(BearerTokenExample.Startup))]

namespace BearerTokenExample
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration configuration = new HttpConfiguration();
            // Ayarlarmız 
            Configure(app);
            WebApiConfig.Register(configuration);
            app.UseWebApi(configuration);

        }

        private void Configure(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new PathString("/getToken"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
                AllowInsecureHttp = true,
                Provider = new MyAuthorizationServerProvider()
            };
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
