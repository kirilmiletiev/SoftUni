namespace IRunes.App.Controllers
{
    using Services.Contracts;
    using SIS.Framework.ActionResults;
    using SIS.Framework.ActionResults.Contracts;
    using SIS.Framework.Attributes.Methods;
    using SIS.Framework.Controllers;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Extensions;
    using ViewModels;

    public class UserController : Controller
    {
        private const string None = "none";
        private const string Inline = "inline";
        private const string DisplayError = "DisplayError";
        private const string ErrorMessage = "ErrorMessage";
        private const string InvalidRegistrationData = "Invalid registration data!";
        private const string UsernameExists = "Username exists!";
        private const string InvalidLoginData = "Invalid username or password!";

        private readonly IUserService userService;
        private readonly IHashService hashService;
        private readonly IUserCookieService userCookieService;

        public UserController(IUserService userService, IHashService hashService, IUserCookieService userCookieService)
        {
            this.userService = userService;
            this.hashService = hashService;
            this.userCookieService = userCookieService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            this.Model.Data[DisplayError] = None;
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterViewModel model)
        {
            var username = model.Username.UrlDecode();
            var password = model.Password.UrlDecode();
            var confirmPassword = model.Confirmpassword.UrlDecode();
            var email = model.Email.UrlDecode();

            if (!this.IsValidModel(username, password, confirmPassword))
            {
                this.Model.Data[DisplayError] = Inline;
                this.Model.Data[ErrorMessage] = InvalidRegistrationData;
                return this.View();
            }

            if (this.userService.ContainsUser(username))
            {
                this.Model.Data[DisplayError] = Inline;
                this.Model.Data[ErrorMessage] = UsernameExists;
                return this.View();
            }

            var hashPassword = this.hashService.Hash(password);
            this.userService.AddUser(username, hashPassword, email);

            // Create cookie and session
            var cookieContent = this.userCookieService.GetUserCookie(username);
            var cookie = new HttpCookie(HttpCookie.Auth, cookieContent, 7) { HttpOnly = true };
            this.Response.Cookies.Add(cookie);

            // Login
            this.SignInUser(username, cookieContent);

            // Response
            return new RedirectResult("/");
        }

        [HttpGet]
        public IActionResult Login()
        {
            this.Model.Data[DisplayError] = None;
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginViewModel model)
        {
            var username = model.Username.UrlDecode();
            var password = model.Password.UrlDecode();

            var hashPassword = this.hashService.Hash(password);
            var user = this.userService.GetUserWithUsernameOrEmail(username, hashPassword);

            if (user == null)
            {
                this.Model.Data[DisplayError] = Inline;
                this.Model.Data[ErrorMessage] = InvalidLoginData;
                return this.View();
            }

            // Login
            var userCookie = this.userCookieService.GetUserCookie(username);
            this.SignInUser(username, userCookie);

            // Response
            return new RedirectResult("/");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            if (!this.Request.Session.ContainsParameter("username"))
            {
                return new RedirectResult("/");
            }

            this.Request.Session.ClearParameters();
            return new RedirectResult("/");
        }

        private bool IsValidModel(string username, string password, string confirmPassword)
        {
            return username.Length >= 3 && password.Length >= 3 && password == confirmPassword;
        }
    }
}