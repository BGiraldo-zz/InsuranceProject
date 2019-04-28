using System.Threading.Tasks;
using Insurance.Domain.AggregatesModel.PolicyAggregate;
using Insurance.Domain.SeedWork;

namespace Insurance.Infrastructure.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        public IUnitOfWork UnitOfWork => throw new System.NotImplementedException();

        public Policy Add(Policy policy)
        {
            throw new System.NotImplementedException();
        }

        public Task<Policy> GetAsync(int policyId)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Policy policy)
        {
            throw new System.NotImplementedException();
        }
    }
}
