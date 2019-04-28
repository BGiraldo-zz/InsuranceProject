using Castle.MicroKernel.Registration;
using Insurance.Domain.AggregatesModel.ClientAggregate;
using Insurance.Domain.AggregatesModel.PolicyAggregate;
using Insurance.Domain.AggregatesModel.PolicyDetailAggregate;
using Insurance.Infrastructure;
using Insurance.Infrastructure.Repositories;

namespace Insurance.MVC.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        public void Install(Castle.Windsor.IWindsorContainer container,
        Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<InsuranceDbContext>()
                    .LifestyleSingleton());

            container.Register(
                Component
                    .For<IClientRepository>()
                    .ImplementedBy<ClientRepository>()
                    .LifestylePerWebRequest());

            container.Register(
                Component
                    .For<IPolicyRepository>()
                    .ImplementedBy<PolicyRepository>()
                    .LifestylePerWebRequest());

            container.Register(
                Component
                    .For<IPolicyDetailRepository>()
                    .ImplementedBy<PolicyDetailRepository>()
                    .LifestylePerWebRequest());
        }
    }
}