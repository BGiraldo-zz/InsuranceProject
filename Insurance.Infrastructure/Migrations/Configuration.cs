namespace Insurance.Infrastructure.Migrations
{
    using Insurance.Domain.AggregatesModel.ClientAggregate;
    using Insurance.Domain.AggregatesModel.PolicyAggregate;
    using Insurance.Domain.AggregatesModel.PolicyDetailAggregate;
    using System;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<Insurance.Infrastructure.InsuranceDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(InsuranceDbContext context)
        {
            context.Clients.AddOrUpdate(
              new Client { ClientId = 0,
                           Identification = 123456789,
                           CompleteName = "Pepito Peréz",
                           Address = "Cr. 12 # 33 - 22 Medellín",
                           Email = "pepito@mail.com",
                           Phone = "00000000" }
            );

            context.Policies.AddOrUpdate(
              new Policy
              {   PolicyId = 0,
                  Name = "Test Policy",
                  Description = "Total Protection",
                  TermBeginning = DateTime.Now,
                  Coverage = 17,
                  CoverageOnMonths = 24,
                  CoveringType = CoveringTypedEnum.Robo,
                  Price  = 3500000,
                  RiskType = RiskTypeEnum.Medio
              }
            );

            context.PolicyDetails.AddOrUpdate(
              new PolicyDetail
              {
                  Client = context.Clients.Find(0),
                  Policy = context.Policies.Find(0),
                  Status = true
              }
            );

        }
    }
}
