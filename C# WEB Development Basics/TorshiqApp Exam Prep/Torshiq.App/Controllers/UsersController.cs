using SIS.Framework.ActionResults;
using SIS.Framework.Attributes.Method;
using SIS.Framework.Controllers;
using System;
using Torshiq.App.ViewModel;

namespace Torshiq.App.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Login()
        {
            return this.View();
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            throw new NotImplementedException();
        }


        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            throw new NotImplementedException();
        }


    }
}
