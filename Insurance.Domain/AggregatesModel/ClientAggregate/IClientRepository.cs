using Insurance.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Insurance.Domain.AggregatesModel.ClientAggregate
{
    public interface IClientRepository : IRepository<Client>
    {
        void Add(Client client);

        void Update(Client client);
    
        Client Get(int? clientId);

        ICollection<Client> GetAll();

        void Remove(int clientId);
    }
}
