using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User?> SignIn(DemoUser user);
        Task<User> AddUser(User newUser);
        Task<User> Update(User user);
    }
}