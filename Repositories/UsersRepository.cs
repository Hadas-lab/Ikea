using Entities;
using System.Text.Json;

namespace Repositories
{
    public class UsersRepository
    {
        static string filePath = "../Repositories/users.txt";
        public async Task<User> SingUp(User newUser)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            newUser.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(newUser);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return newUser;
        }

        public async Task<User> SignIn(User user)
        {
            User userFound = await findUser(user);
            if (userFound == null)
                return null;
            return userFound;
        }

        private async Task<User> findUser(User user)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User u = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (u != null && u.Email == user.Email && u.Password == user.Password)
                        return u;
                }
            }
            return null;
        }

        public async Task Update(int id, User user)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile = reader.ReadLine();
                while (currentUserInFile != null)
                {
                    User currentUser = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (currentUser.Id == id)
                        textToReplace = currentUserInFile;
                    currentUserInFile = reader.ReadLine();
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(user));
                System.IO.File.WriteAllText(filePath, text);
            }

        }


    }
}