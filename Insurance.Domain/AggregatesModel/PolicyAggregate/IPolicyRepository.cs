using Insurance.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurance.Domain.AggregatesModel.PolicyAggregate
{
    public interface IPolicyRepository: IRepository<Policy>
    {
        void Add(Policy policy);

        void Update(Policy policy);

        Policy Get(int? policyId);

        ICollection<Policy> GetAll();

        void Remove(int policyId);
    }
}
