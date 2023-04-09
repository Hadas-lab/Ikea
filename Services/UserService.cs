using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace Services
{
    public class UserService : IUserService
    {
        IUserRepository _usersRepository;

        public UserService(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }


        public async Task<User> SingUp(User newUser)
        {
            User user = await _usersRepository.AddUser(newUser);
            return user;
        }


        public async Task<User?> SignIn(DemoUser user)
        {
            User? userFound = await _usersRepository.SignIn(user);
            return userFound;
        }

        public async Task<User> Put(int id, User user)
        {
            return await _usersRepository.Update(user);
        }

    }
}