using Insurance.Domain.SeedWork;
using System.Threading.Tasks;

namespace Insurance.Domain.AggregatesModel.UserAggregate
{
    public interface IUserRepository: IRepository<User>
    {
        User Add(User user);

        void Update(User obj);

        Task<User> GetAsync(int userId);
    }
}
