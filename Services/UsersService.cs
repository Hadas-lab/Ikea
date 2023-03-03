using Entities;
using Repositories;

namespace Services
{
    public class UsersService
    {
        UsersRepository usersRepository = new();
        public User SingUp(User newUser)
        {
            User user = usersRepository.SingUp(newUser);
            return user;
        }


        public User SignIn(User user)
        {
            User userFound = usersRepository.SignIn(user);
            return userFound;
        }

        public void Put(int id, User user)
        {
            usersRepository.Update(id, user);
        }

    }
}