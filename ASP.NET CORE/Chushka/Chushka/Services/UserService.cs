using System.Linq;
using Chushka.Data;
using Chushka.Data.Models;
using Chushka.Models;
using Chushka.Services.Contracts;

namespace Chushka.Services
{
    public class UserService : IUserService
    {
        private ChushkaDbContext context;

        public UserService(ChushkaDbContext context)
        {
            this.context = context;
        }

        public ChushkaUser GetUser(string username)
        {
            bool isAnyUser = context.Users.Any(u => u.UserName == username);


            if (!isAnyUser)
            {
                return null;
            }

            return context.Users.FirstOrDefault(u => u.UserName == username);
        }

        public void AddUser(ChushkaUser user)
        {
            if (GetUser(user.UserName) == null)
            {
                user.CustomRole = !IsAnyUserInContext() ? CustomRole.Admin : CustomRole.User;

                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public bool IsAnyUserInContext()
        {
            return context.Users.Any();
        }

        public bool IsUserLogIn(LoginViewModel model)
        {
           var user = context.Users.FirstOrDefault(x => x.UserName == model.Username);

            return user.IsLoggedIn;

        }

        
    }
}
