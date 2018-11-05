using PANDA.App.Models;

namespace PANDA.App.Services.Contracts
{
    public interface IUserService
    {
        User RegisterUser(string username, string password, string confirmPassword, string email);

        bool IsUserExist(string username);

        User GetUser(string username, string password);

    }
}
