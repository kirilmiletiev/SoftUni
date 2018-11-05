using System.Collections.Generic;
using PANDA.App.Models.Enums;
using PANDA.App.Services.Contracts;
using PANDA.App.ViewModel;
using SIS.Framework.ActionResults;
using SIS.Framework.ActionResults.Implementations;
using SIS.Framework.Attributes.Method;
using SIS.Framework.Security;

namespace PANDA.App.Controllers
{
    public class UsersController : BaseController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }


        //public IActionResult Receipts()
        //{
        //    return this.View();
        //}


        public IActionResult Login()
        {

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var IsUserExist = userService.IsUserExist(model.Username);

            if (!IsUserExist)
            {
                return RedirectToAction("/Users/Register");
            }

            var user = userService.GetUser(model.Username, model.Password);
            
            
            if (user == null)
            {
                return new RedirectResult("/");
            }
            else
                this.SignIn(new IdentityUser()
                {
                    Username = user.Username,
                    Password = user.Password,
                    Email = user.Email,
                    Roles = new List<string>() { user.Role.ToString()}

                });
            return new RedirectResult("/");
           // return this.View();
        }

        public IActionResult Register()
        {

            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
           var user = userService.RegisterUser(model.Username, model.Password,model.ConfirmPassword, model.Email);

            this.SignIn(new IdentityUser()
            {
                Email = model.Email,
                Password = model.Password,
                Username = model.Username,
                IsValid = true,
                Roles = new List<string>() { user.Role.ToString() },

            });

            return RedirectToAction("/");

            //return this.View();
        }


        [HttpGet]
        public IActionResult Logout()
        {
            this.SignOut();
            return new RedirectResult("/");
        }

    }
}
