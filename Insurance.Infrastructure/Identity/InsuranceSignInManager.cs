using Insurance.Infrastructure.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Insurance.Infrastructure.Identity
{

    // Configure the application sign-in manager which is used in this application.
    public class InsuranceSignInManager : SignInManager<InsuranceUser, int>
    {
        public InsuranceSignInManager(InsuranceUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(InsuranceUser user)
        {
            return user.GenerateUserIdentityAsync((InsuranceUserManager)UserManager);
        }

        public static InsuranceSignInManager Create(IdentityFactoryOptions<InsuranceSignInManager> options, IOwinContext context)
        {
            return new InsuranceSignInManager(context.GetUserManager<InsuranceUserManager>(), context.Authentication);
        }
    }
}
