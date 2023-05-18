using Entities;
using DTO;
namespace Services
{
    public interface IUserService
    {
        Task<bool> Put(int id, User user);
        Task<User?> SignIn(UserLoginDto user);
        Task<User> SingUp(User newUser);
    }
}