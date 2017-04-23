using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Threading.Tasks;
using PomodoroEnterprise.API.EF;

namespace PomodoroEnterprise.API.Providers
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity("otc");
            var username = context.OwinContext.Get<string>("otc:username");
            var userid = context.OwinContext.Get<string>("otc:userid");
            identity.AddClaim(new Claim("username", username));
            identity.AddClaim(new Claim("userid", userid));
            identity.AddClaim(new Claim("role", "user"));
            context.Validated(identity);
            return Task.FromResult(0);
        }

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            try
            {
                var username = context.Parameters["username"];
                var password = context.Parameters["password"];

                using (DataContext db = new DataContext())
                {
                    password = password.Hash();
                    var user = db.Users.SingleOrDefault(u => u.Username == username & u.Password == password);
                    if (user != null)
                    {
                        context.OwinContext.Set("otc:username", username);
                        context.OwinContext.Set("otc:userid", user.Id.ToString());
                        context.Validated();
                    }
                    else
                    {
                        context.SetError("Invalid credentials");
                        context.Rejected();
                    }
                }
            }
            catch (Exception ex)
            {
                context.SetError("Server error");
                context.Rejected();
            }
            return Task.FromResult(0);
        }
    }
}