using SIS.Framework.ActionResults;

namespace Torshiq.App.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
