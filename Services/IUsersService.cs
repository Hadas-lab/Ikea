using Entities;

namespace Services
{
    public interface IUsersService
    {
        Task Put(int id, User user);
        Task<User> SignIn(User user);
        Task<User> SingUp(User newUser);
    }
}