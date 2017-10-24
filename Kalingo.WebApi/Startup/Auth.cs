using System.Configuration;
using System.IdentityModel.Tokens;
using Microsoft.Owin.Security.ActiveDirectory;
using Owin;

namespace Kalingo.WebApi.Startup
{
    public class Auth
    {
        public static void ConfigureAuth(IAppBuilder app)
        {
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                {
                    //ConfigurationManager.AppSettings["Tenant"]
                    Tenant = "rohanmayekar29outlook.onmicrosoft.com",
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        //ConfigurationManager.AppSettings["Audience"],
                        ValidAudience = "https://rohanmayekar29outlook.onmicrosoft.com/KalingoApi"  
                    }
                });
        }
    }
}