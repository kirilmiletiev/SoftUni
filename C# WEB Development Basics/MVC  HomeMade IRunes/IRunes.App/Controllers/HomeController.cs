namespace IRunes.App.Controllers
{
    using SIS.Framework.ActionResults.Contracts;
    using SIS.Framework.Attributes.Methods;
    using SIS.Framework.Controllers;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            if (this.IsLoggedIn())
            {
                var username = this.Request.Session.GetParameter("username");
                this.Model.Data["Username"] = username;

                return this.View("Index-Logged-In");
            }

            return this.View();
        }
    }
}