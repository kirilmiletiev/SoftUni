using Chushka.Data.Models;
using Chushka.Models;

namespace Chushka.Services.Contracts
{
    public interface IUserService
    {
        void AddUser(ChushkaUser user);

        ChushkaUser GetUser(string username);

        bool IsAnyUserInContext();

        bool IsUserLogIn(LoginViewModel model);
    }
}