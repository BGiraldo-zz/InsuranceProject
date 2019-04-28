using Insurance.Domain.AggregatesModel.ClientAggregate;
using Insurance.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Insurance.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly InsuranceDbContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public ClientRepository(InsuranceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChangesAsync();
        }

        public Client Get(int? clientId)
        {
            return _context.Clients.Find(clientId);
        }

        public ICollection<Client> GetAll()
        {
            return _context.Clients.ToList();
        }

        public void Remove(int clientId)
        {
            Client client = this.Get(clientId);
            _context.Clients.Remove(client);
            _context.SaveChangesAsync();
        }

        public void Update(Client client)
        {
            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }
    }
}
