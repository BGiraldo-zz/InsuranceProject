using Insurance.Domain.AggregatesModel.ClientAggregate;
using Insurance.Domain.AggregatesModel.PolicyAggregate;
using Insurance.Domain.AggregatesModel.PolicyDetailAggregate;
using Insurance.Domain.SeedWork;
using Insurance.Infrastructure.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace Insurance.Infrastructure
{
    public class InsuranceDbContext : IdentityDbContext<InsuranceUser, InsuranceRole, int, InsuranceUserLogin, InsuranceUserRole, InsuranceUserClaim>, IUnitOfWork
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Policy> Policies { get; set; }
        public DbSet<PolicyDetail> PolicyDetails { get; set; }

        public InsuranceDbContext()
            : base("SQLConnString")
        {
        }

        public static InsuranceDbContext Create()
        {
            return new InsuranceDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Map Entities to their tables.
                   modelBuilder.Entity<InsuranceUser>().ToTable("InsuranceUser");
                   modelBuilder.Entity<InsuranceRole>().ToTable("InsuranceRole");
                   modelBuilder.Entity<InsuranceUserClaim>().ToTable("User_Claim");
                   modelBuilder.Entity<InsuranceUserLogin>().ToTable("User_Login");
                   modelBuilder.Entity<InsuranceUserRole>().ToTable("User_Role");
                   // Set AutoIncrement-Properties
                   modelBuilder.Entity<InsuranceUser>().Property(r => r.Id).HasColumnName("UserId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                   modelBuilder.Entity<InsuranceUserClaim>().Property(r => r.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                   modelBuilder.Entity<InsuranceRole>().Property(r => r.Id).HasColumnName("RoleId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                   // Override some column mappings that do not match our default
                   modelBuilder.Entity<InsuranceUser>().Property(r => r.UserName).HasColumnName("LoginId");
                   modelBuilder.Entity<InsuranceUser>().Property(r => r.PasswordHash).HasColumnName("Password");
                   modelBuilder.Entity<InsuranceUser>().Property(r => r.PhoneNumber).HasColumnName("Telephone");
                   modelBuilder.Entity<InsuranceRole>().Property(r => r.Name).HasColumnName("RoleName");
                   modelBuilder.Entity<InsuranceUserClaim>().Property(r => r.UserId).HasColumnName("UserId");
                   modelBuilder.Entity<InsuranceUserLogin>().Property(r => r.UserId).HasColumnName("UserId");
                   modelBuilder.Entity<InsuranceUserRole>().Property(r => r.UserId).HasColumnName("UserId");
                   modelBuilder.Entity<InsuranceUserRole>().Property(r => r.RoleId).HasColumnName("RoleId");

        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var result = await base.SaveChangesAsync();

            return true;
        }
    }
}
