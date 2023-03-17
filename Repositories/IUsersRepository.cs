using Entities;

namespace Repositories
{
    public interface IUsersRepository
    {
        Task<User> SignIn(User user);
        Task<User> SingUp(User newUser);
        Task Update(int id, User user);
    }
}