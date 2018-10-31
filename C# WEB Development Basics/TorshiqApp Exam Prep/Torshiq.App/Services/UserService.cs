using System.Linq;
using Torshiq.App.Services.Contracts;
using Torshiq.Data;
using Torshiq.Models;
using Torshiq.Models.Enums;

namespace Torshiq.App.Services
{
    public class UserService: IUserService
    {
        private readonly TorshiqDbContext context;

        public UserService(TorshiqDbContext context)
        {
            this.context = context;
        }

        public void AddUser(string username, string password, string email)
        {
            

            Role role = context.Users.Any() ? Role.User : Role.Admin;

            var user = new User()
            {
                Email = email,
                Username = username,
                Password = password,
                Role = role
            };

            context.Users.Add(user);
            context.SaveChanges();
        }

        public User GetUser(string username)
        {
            var user = context
                .Users
                .FirstOrDefault(u => u.Username == username);

            return user;
        }

        public User GetUser(string username, string password)
        {
            var user = context
                .Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            return user;
        }

        public bool IsUserExist(string username)
        {
            return context
                .Users.Any(u => u.Username == username);
        }

        public bool AreThereUsers()
        {
            return context
                .Users.Any();
        }
    }
}
