namespace IRunes.App.Controllers
{
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;

    public class HomeController : Controller
    {
        public IHttpResponse Index(IHttpRequest request)
        {
            if (this.IsAuthenticated(request))
            {
                var username = request.Session.GetParameter("username");
                this.ViewBag["Username"] = username.ToString();

                return this.View("index-logged-in", this.ViewBag);
            }

            return this.View("index", this.ViewBag);
        }
    }
}