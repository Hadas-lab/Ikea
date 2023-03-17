using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//to change: SignIn=>addNawUser . private: _

namespace Repositories
{
    public class UsersRepository : IUsersRepository
    {
        IkeaContext _ikeaContext;

        public UsersRepository(IkeaContext ikeaContext)
        {
            _ikeaContext = ikeaContext;
        }

        public async Task<User> SignIn(User user)
        {
            //await _ikeaContext.Users.AddAsync(user);
            //await _ikeaContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> SingUp(User newUser)
        {
            throw new NotImplementedException();
        }

        public async Task Update(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
