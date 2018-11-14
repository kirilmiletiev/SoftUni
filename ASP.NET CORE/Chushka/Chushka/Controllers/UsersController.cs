using System.Security.Claims;
using Chushka.Data.Migrations;
using Chushka.Data.Models;
using Chushka.Models;
using Chushka.Services.Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Chushka.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService service;

        public UsersController(IUserService service)
        {
            this.service = service;
        }


        [HttpGet]
        public IActionResult Login()
        {

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            //var a = this.signInManager.Context.User.Identity.IsAuthenticated;
            var b = service.GetUser(model.Username);

            if (b != null && b.IsLoggedIn)
            {
                this.ViewData["Message"] = "You are Logged In!";
            }
            else
            {
                ChushkaUser user = this.service.GetUser(model.Username);

                if (user != null)
                {
                    user.IsLoggedIn = true;
                }
            }


            return RedirectPermanent("/");
        }

        [HttpGet]
        public IActionResult Register()
        {

            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            ChushkaUser user = new ChushkaUser()
            {
                UserName = model.Username,

                PasswordHash = model.Password,

                FullName = model.FullName,

                Email = model.Email,

                EmailConfirmed = true,

                IsLoggedIn = true

                //ConfirmPassword/??
            };

            this.service.AddUser(user);

            //return this.View();
            return this.RedirectPermanent("/");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            this.SignOut();
            return RedirectPermanent("/");
        }
    }

}
