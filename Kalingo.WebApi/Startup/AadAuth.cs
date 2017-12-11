using System.Configuration;
using System.IdentityModel.Tokens;
using Microsoft.Owin.Security.ActiveDirectory;
using Owin;

namespace Kalingo.WebApi.Startup
{
    public class AadAuth
    {
        public static void ConfigureAuth(IAppBuilder app)
        {
            app.UseWindowsAzureActiveDirectoryBearerAuthentication(
                new WindowsAzureActiveDirectoryBearerAuthenticationOptions
                {
                    //CloudConfigurationManager.GetSetting("Tenant")
                    Tenant = "rohanmayekar29outlook.onmicrosoft.com",
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        //CloudConfigurationManager.GetSetting("Audience),
                        ValidAudience = "https://rohanmayekar29outlook.onmicrosoft.com/KalingoApi"  
                    }
                });
        }
    }
}