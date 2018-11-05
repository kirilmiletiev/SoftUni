using SIS.Framework.ActionResults;

namespace PANDA.App.Controllers
{
   public  class ReceiptsController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Details()
        {
            return this.View();
        }
    }
}
