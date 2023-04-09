using Entities;

namespace Services
{
    public interface IUserService
    {
        Task<User> Put(int id, User user);
        Task<User?> SignIn(DemoUser user);
        Task<User> SingUp(User newUser);
    }
}