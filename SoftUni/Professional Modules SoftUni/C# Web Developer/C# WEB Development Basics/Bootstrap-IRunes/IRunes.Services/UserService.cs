namespace IRunes.Services
{
    using Data;
    using Models;
    using Contracts;
    using System.Linq;

    public class UserService : IUserService
    {
        public void AddUser(string username, string hashPassword, string email)
        {
            using (var context = new IRunesDbContext())
            {
                var user = new User()
                {
                    Username = username,
                    Password = hashPassword,
                    Email = email
                };

                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public bool ContainsUser(string username)
        {
            using (var context = new IRunesDbContext())
            {
                var isExist = context
                    .Users
                    .Any(u => u.Username == username);

                return isExist;
            }
        }

        public User GetUser(string username, string hashPassword)
        {
            using(var content = new IRunesDbContext())
            {
                var user = content
                    .Users
                    .FirstOrDefault(x => x.Username == username && x.Password == hashPassword);

                return user;
            }
        }

        public User GetUserWithUsernameOrEmail(string usernameOrEmail, string hashPassword)
        {
            using (var content = new IRunesDbContext())
            {
                var user = content
                    .Users
                    .FirstOrDefault(x => (x.Username == usernameOrEmail || x.Email == usernameOrEmail) && x.Password == hashPassword);

                return user;
            }
        }
    }
}