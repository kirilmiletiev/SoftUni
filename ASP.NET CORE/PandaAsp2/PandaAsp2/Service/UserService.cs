using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PandaAsp2.Data;
using PandaAsp2.Data.Models;
using PandaAsp2.Service.Contracts;

namespace PandaAsp2.Service
{
    public class UserService : IUserService
    {
        private ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public User GetUser(string username)
        {
            bool isAnyUser = context.Users.Any(u => u.UserName == username);
           

            if (!isAnyUser)
            {
                return null;
            }

            return context.Users.FirstOrDefault(u => u.UserName == username);
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public bool IsAnyUserInContext()
        {
            return context.Users.Any();
        }
    }
}
