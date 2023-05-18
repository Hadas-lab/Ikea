using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IkeaContext _ikeaContext;


        public UserRepository(IkeaContext ikeaContext)
        {
            _ikeaContext = ikeaContext;
        }

        public async Task<User?> SignIn(UserLoginDto user)
        {
            User userFound = await _ikeaContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password);
            return userFound;
        }

        public async Task<bool> UniqueEmail(String email)
        {
            User user = await _ikeaContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user == null;
        }

        public async Task<User> AddUser(User newUser)
        {
            await _ikeaContext.Users.AddAsync(newUser);
            await _ikeaContext.SaveChangesAsync();
            return newUser;
        }

        public async Task<bool> Update(User user)
        {
            _ikeaContext.Users.Update(user);
            await _ikeaContext.SaveChangesAsync();
            return true;
        }

    }
}
