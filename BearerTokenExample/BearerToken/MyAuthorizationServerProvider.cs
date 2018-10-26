using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace BearerTokenExample.BearerToken
{
    public class MyAuthorizationServerProvider:OAuthAuthorizationServerProvider
    {


        public override async Task  ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (context.UserName.Equals("ertan",StringComparison.OrdinalIgnoreCase) && context.Password.Equals("123456"))
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("role", "user"));
                context.Validated(identity);
            }
            else
            {
                context.SetError("Oturum Hatası", "Kullanıcı Adı veya şifre hatalı");
            }
        }



    }
}