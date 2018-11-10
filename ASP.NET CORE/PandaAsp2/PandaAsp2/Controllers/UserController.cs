using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PandaAsp2.ViewModels;

namespace PandaAsp2.Controllers
{
    public class UserController : Controller
    {
        //private IdentityUser identity;

        //public UserController(IdentityUser identity)
        //{
        //    this.identity = identity;
        //}

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
            return View();
        }

        public IActionResult Logout()
        {
           //TODO: LOGOUT?
            return new RedirectResult("/");
        }
    }
}
