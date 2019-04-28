using Insurance.Domain.AggregatesModel.UserAggregate;
using Insurance.Domain.SeedWork;
using System;
using System.Threading.Tasks;

namespace Insurance.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public User Add(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public void Update(User obj)
        {
            throw new NotImplementedException();
        }
    }
}
