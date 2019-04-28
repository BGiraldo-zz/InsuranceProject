using Insurance.Infrastructure;
using Insurance.Infrastructure.Identity;
using Insurance.Infrastructure.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Configuration;

namespace Insurance.MVC
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(InsuranceDbContext.Create);
            app.CreatePerOwinContext<InsuranceUserManager>(InsuranceUserManager.Create);
            app.CreatePerOwinContext<InsuranceSignInManager>(InsuranceSignInManager.Create);
            app.CreatePerOwinContext<InsuranceRoleManager>(InsuranceRoleManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<InsuranceUserManager, InsuranceUser, int>(
                        TimeSpan.FromMinutes(Convert.ToInt32(ConfigurationManager.AppSettings["SignOutInterval"])),
                        (manager, user) => user.GenerateUserIdentityAsync(manager),
                        identity => int.Parse(identity.GetUserId()))
                }
            });
        }
    }
}