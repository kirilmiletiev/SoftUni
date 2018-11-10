using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PandaAsp2.Data.Models;
using PandaAsp2.Data.Models.Enums;
using PandaAsp2.Service.Contracts;
using PandaAsp2.ViewModels;

namespace PandaAsp2.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            var isUserExist = userService.GetUser(model.Username);

            if (isUserExist != null)
            {
                Role role = !userService.IsAnyUserInContext() ? Role.Admin : Role.User;

                User user = new User()
                {
                    UserName = model.Username,
                    Password = model.Password,
                    Email = model.Email,
                    Role = role
                };

                userService.AddUser(user);
            }

            return View();
        }

        public IActionResult Logout()
        {
            //TODO: LOGOUT?
            return new RedirectResult("/");
        }
    }
}
