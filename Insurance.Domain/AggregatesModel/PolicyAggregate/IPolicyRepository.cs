using Insurance.Domain.SeedWork;
using System.Threading.Tasks;

namespace Insurance.Domain.AggregatesModel.PolicyAggregate
{
    public interface IPolicyRepository: IRepository<Policy>
    {
        Policy Add(Policy policy);

        void Update(Policy policy);

        Task<Policy> GetAsync(int policyId);
    }
}
