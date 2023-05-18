using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using DTO;
using Microsoft.Extensions.Logging;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _usersRepository;
        private readonly IPasswordService _passwordService;


        public UserService(IUserRepository usersRepository, IPasswordService passwordService)
        {
            _passwordService = passwordService;
            _usersRepository = usersRepository;
        }


        public async Task<User> SingUp(User newUser)
        {
            int strength = await _passwordService.passwordScore(newUser.Password);
            bool unique = await _usersRepository.UniqueEmail(newUser.Email);
            if (!unique || strength < 2)
            {
                return null;
            }
            User user = await _usersRepository.AddUser(newUser);
            return user;
        }


        public async Task<User?> SignIn(UserLoginDto user)
        {
            User? userFound = await _usersRepository.SignIn(user);
            return userFound;
        }

        public async Task<bool> Put(int id, User user)
        {
            int strength = await _passwordService.passwordScore(user.Password);
            bool unique = await _usersRepository.UniqueEmail(user.Email);
            if (!unique || strength < 2)
            {
                return false;
            }
            return await _usersRepository.Update(user);
        }

    }
}