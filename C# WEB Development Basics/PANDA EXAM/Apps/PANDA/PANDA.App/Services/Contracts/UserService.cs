using System;
using System.Linq;
using PANDA.App.Data;
using PANDA.App.Models;
using PANDA.App.Models.Enums;

namespace PANDA.App.Services.Contracts
{
    public class UserService : IUserService
    {
        private readonly PandaContext context;

        public UserService(PandaContext context)
        {
            this.context = context;
        }

        public User RegisterUser(string username, string password, string confirmPassword, string email)
        {


            Role role;

            if (!context.Users.Any())
            {
                role = Role.Admin;
            }
            else
            {
                role = Role.User;
            }

            var user = new User()
            {
                Username = username,
                Password = password,
                Email = email,
                Role = role 
            };

            context.Users.Add(user);
            context.SaveChanges();

            return user;

        }

        //public User LoginUser(string username, string password)
        //{
        //    if (!IsUserExist(username))
        //    {
        //        return RedirectToAction("/Users/Register");
        //    }
        //}

        public bool IsUserExist(string username)
        {
            return context
                .Users.Any(u => u.Username == username);
        }

        public User GetUser(string username, string password)
        {
            var user = context
                .Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            return user;
        }
    }
}
