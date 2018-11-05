using SIS.Framework.ActionResults;

namespace PANDA.App.Controllers
{
    public class PackagesController : BaseController
    {
        public IActionResult Details()
        {
            return this.View();
        }
    }
}
