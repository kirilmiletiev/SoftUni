using SIS.Framework.ActionResults;
using SIS.Framework.Attributes.Method;
using System;
using SIS.Framework.ActionResults.Implementations;
using SIS.Framework.Security;
using Torshiq.App.Services.Contracts;
using Torshiq.App.ViewModel;

namespace Torshiq.App.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Login()
        {

            return this.View();
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var userExist = userService.IsUserExist(model.Username);

            if (!userExist)
            {
                return RedirectToAction("/Users/Register");
            }

            this.SignIn(new IdentityUser()
            {
                Username = model.Username,
                Password = model.Password,
            });

            return new RedirectResult("/");
        }


        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            this.userService.AddUser(model.Username,model.Password, model.Email );

            this.SignIn(new IdentityUser()
            {
                Email = model.Email,
                Password = model.Password,
                Username = model.Username,
            });

            return RedirectToAction("/");
        }


    }
}
