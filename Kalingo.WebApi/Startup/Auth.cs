using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
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
                    Audience = "https://rohanmayekar29outlook.onmicrosoft.com/KalingoApi",  //ConfigurationManager.AppSettings["Audience"],
                    Tenant = "https://rohanmayekar29outlook.onmicrosoft.com" //ConfigurationManager.AppSettings["Tenant"]
                });
        }
    }
}