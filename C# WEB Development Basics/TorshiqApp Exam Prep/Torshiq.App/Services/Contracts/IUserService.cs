
using Torshiq.Models;
using Torshiq.Models.Enums;

namespace Torshiq.App.Services.Contracts
{
    public interface IUserService
    {
        User AddUser(string username, string password, string email);

        User GetUser(string username);

        User GetUser(string username, string password);

        bool IsUserExist(string username);

        bool AreThereUsers();
    }
}
