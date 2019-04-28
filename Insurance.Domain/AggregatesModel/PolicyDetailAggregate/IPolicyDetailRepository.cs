using Insurance.Domain.AggregatesModel.ClientAggregate;
using Insurance.Domain.AggregatesModel.PolicyAggregate;
using Insurance.Domain.SeedWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Domain.AggregatesModel.PolicyDetailAggregate
{
    public interface IPolicyDetailRepository: IRepository<PolicyDetail>
    {
        void Add(PolicyDetail policy);

        void Update(PolicyDetail policy);

        PolicyDetail Get(int? policyId);

        IQueryable<PolicyDetail> Include();

        ICollection<PolicyDetail> GetAll();

        void Remove(int policyId);

        ICollection<Client> GetClients();

        ICollection<Policy> GetPolicies();
    }
}
