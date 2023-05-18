using Entities;
using DTO;

namespace Repositories
{
    public interface IUserRepository
    {
        Task<User?> SignIn(UserLoginDto user);
        Task<User> AddUser(User newUser);
        Task<bool> Update(User user);
        Task<bool> UniqueEmail(string email);
    }
}