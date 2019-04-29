using Insurance.Domain.AggregatesModel.ClientAggregate;
using Insurance.Domain.AggregatesModel.PolicyAggregate;
using Insurance.Domain.AggregatesModel.PolicyDetailAggregate;
using Insurance.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Insurance.Infrastructure.Repositories
{
    public class PolicyDetailRepository : IPolicyDetailRepository
    {

        private readonly InsuranceDbContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public PolicyDetailRepository(InsuranceDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(PolicyDetail policy)
        {
            _context.PolicyDetails.Add(policy);
            _context.SaveChanges();
        }

        public PolicyDetail Get(int? policyId)
        {
            return _context.PolicyDetails.Find(policyId);
        }

        public ICollection<PolicyDetail> GetAll()
        {
            return _context.PolicyDetails.ToList();
        }

        public void Remove(int policyId)
        {
            PolicyDetail policyDetail = this.Get(policyId);
            _context.PolicyDetails.Remove(policyDetail);
            _context.SaveChanges();
        }

        public void Update(PolicyDetail policy)
        {
            var entity = _context.PolicyDetails.Find(policy.PolicyDetailId);
            if (entity == null)
            {
                return;
            }

            _context.Entry(entity).CurrentValues.SetValues(policy);
            _context.SaveChanges();
        }

        public IQueryable<PolicyDetail> Include()
        {
           return _context.PolicyDetails.Include(p => p.Client).Include(p => p.Policy);
        }

        public ICollection<Client> GetClients()
        {
            return _context.Clients.ToList();
        }

        public ICollection<Policy> GetPolicies()
        {
            return _context.Policies.ToList();
        }
    }
}
