using SIS.Framework.ActionResults;
using SIS.Framework.Attributes.Method;
using System;
using System.Collections.Generic;
using SIS.Framework.ActionResults.Implementations;
using SIS.Framework.Security;
using SIS.Framework.Views;
using Torshiq.App.Services.Contracts;
using Torshiq.App.ViewModel;
using Torshiq.Models.Enums;

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

            if (userService.GetUser(model.Username,model.Password) == null)
            {
                return new RedirectResult("/");
            }
            else
            {
                this.SignIn(new IdentityUser()
                {
                    Username = model.Username,
                    Password = model.Password,
                    IsValid = model.IsValid,
                    Roles = model.Roles,

                });
            }

           

            return new RedirectResult("/");
        }


        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
           var user = this.userService.AddUser(model.Username, model.Password, model.Email);

            var role = user.Role.ToString();

            this.SignIn(new IdentityUser()
            {
                Email = model.Email,
                Password = model.Password,
                Username = model.Username,
                IsValid = true,
                Roles = new List<string>() {role},
                
            });

            
            return RedirectToAction("/");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            this.SignOut();
            return new RedirectResult("/");
        }


    }
}
