using Entities;
using Repositories;

namespace Services
{
    public class UsersService
    {
        UsersRepository usersRepository = new();
        public async Task<User> SingUp(User newUser)
        {
            User user = await usersRepository.SingUp(newUser);
            return user;
        }


        public async Task<User> SignIn(User user)
        {
            User userFound = await usersRepository.SignIn(user);
            return userFound;
        }

        public async Task Put(int id, User user)
        {
            await usersRepository.Update(id, user);
        }

    }
}