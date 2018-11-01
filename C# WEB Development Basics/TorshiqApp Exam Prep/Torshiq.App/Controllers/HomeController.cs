using SIS.Framework.ActionResults;
using SIS.Framework.Attributes.Method;
using Torshiq.App.ViewModel;

namespace Torshiq.App.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            if (this.Identity==null)
            {
                return this.View();
            }

            return this.View("/UserIndex");
        }

        [HttpGet]
        public IActionResult Index(LoginViewModel model)
        {


            return this.View();
        }
    }
}
