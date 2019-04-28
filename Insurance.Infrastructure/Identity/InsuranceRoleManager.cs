using Insurance.Infrastructure.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Insurance.Infrastructure.Identity
{
    public class InsuranceRoleManager : RoleManager<InsuranceRole, int>
    {
        public InsuranceRoleManager(IRoleStore<InsuranceRole, int> store) : base(store)
        {

        }

        public static InsuranceRoleManager Create(IdentityFactoryOptions<InsuranceRoleManager> options, IOwinContext context)
        {
            var manager = new InsuranceRoleManager(new RoleStore<InsuranceRole, int, InsuranceUserRole>(context.Get<InsuranceDbContext>()));
            return manager;
        }
    }
}
