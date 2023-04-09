using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private IkeaContext _ikeaContext;

        public UserRepository(IkeaContext ikeaContext)
        {
            _ikeaContext = ikeaContext;
        }

        public async Task<User?> SignIn(DemoUser user)
        {
            
            User userFound = await _ikeaContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password);
            return userFound;
        }

        public async Task<User> AddUser(User newUser)
        {
            await _ikeaContext.Users.AddAsync(newUser);
            await _ikeaContext.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> Update(User user)
        {
            _ikeaContext.Users.Update(user);
            await _ikeaContext.SaveChangesAsync();
            return user;
        }

    }
}
