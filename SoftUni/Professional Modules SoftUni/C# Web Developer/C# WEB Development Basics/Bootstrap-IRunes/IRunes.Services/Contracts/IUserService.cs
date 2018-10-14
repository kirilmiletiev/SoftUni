namespace IRunes.Services.Contracts
{
    using Models;

    public interface IUserService
    {
        User GetUser(string username, string hashPassword);

        User GetUserWithUsernameOrEmail(string usernameOrEmail, string hashPassword);

        void AddUser(string username, string hashPassword, string email);

        bool ContainsUser(string username);
    }
}