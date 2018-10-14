namespace IRunes.App.Controllers
{
    using Extensions;
    using Services;
    using Services.Contracts;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;

    public class UsersController : Controller
    {
        private const string InvalidUsernameOrPassword = "Invalid username, email or password!";
        private const string InvalidUsernameOrPasswordLength = "Invalid user data!";
        private const string UsernameAlreadyExists = "Username already exists!";

        private readonly IUserService userService;
        private readonly IHashService hashService;

        public UsersController()
        {
            this.userService = new UserService();
            this.hashService = new HashService();
        }

        public IHttpResponse Login()
        {
            return this.View("login", this.ViewBag);
        }
        
        public IHttpResponse Login(IHttpRequest request)
        {
            var usernameOrEmail = request.FormData["usernameOrEmail"].ToString().UrlDecode();
            var password = request.FormData["password"].ToString().UrlDecode();

            var hashPassword = this.hashService.Hash(password);
            var user = this.userService.GetUserWithUsernameOrEmail(usernameOrEmail, hashPassword);

            if (user == null)
            {
                this.ViewBag["Error"] = InvalidUsernameOrPassword;
                this.ViewBag["BackTo"] = $"<a class=\"btn btn-warning btn-lg\" href=\"/users/login\" role=\"button\">Back To Login</a>";
                return this.View("error", this.ViewBag);
            }

            var response = new RedirectResult("/");
            this.SignInUser(usernameOrEmail, request, response);
            return response;
        }

        public IHttpResponse Register()
        {
            return this.View("register", this.ViewBag);
        }

        public IHttpResponse Register(IHttpRequest request)
        {
            var username = request.FormData["username"].ToString().UrlDecode();
            var password = request.FormData["password"].ToString().UrlDecode();
            var confirmPassword = request.FormData["confirmPassword"].ToString().UrlDecode();
            var email = request.FormData["email"].ToString().UrlDecode();

            if (username.Length < 4 || password.Length < 4 || password != confirmPassword)
            {
                this.ViewBag["Error"] = InvalidUsernameOrPasswordLength;
                this.ViewBag["BackTo"] = $"<a class=\"btn btn-warning btn-lg\" href=\"/users/register\" role=\"button\">Back To Register</a>";
                return this.View("error", this.ViewBag);
            }

            if (this.userService.ContainsUser(username))
            {
                this.ViewBag["Error"] = UsernameAlreadyExists;
                this.ViewBag["BackTo"] = $"<a class=\"btn btn-warning btn-lg\" href=\"/users/register\" role=\"button\">Back To Register</a>";
                return this.View("error", this.ViewBag);
            }

            var hashPassword = this.hashService.Hash(password);
            this.userService.AddUser(username, hashPassword, email);

            var response = new RedirectResult("/");
            this.SignInUser(username, request, response);
            return response;
        }

        public IHttpResponse Logout(IHttpRequest request)
        {
            if (!request.Session.ContainsParameter("username"))
            {
                return new RedirectResult("/");
            }

            request.Session.ClearParameters();
            return new RedirectResult("/");
        }
    }
}