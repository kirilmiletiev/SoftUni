using System.Security.Principal;

namespace SIS.Framework.Controllers
{
    using System.Runtime.CompilerServices;
    using ActionResults;
    using ActionResults.Contracts;
    using HTTP.Cookies;
    using HTTP.Enums;
    using HTTP.Requests.Contracts;
    using HTTP.Responses;
    using HTTP.Responses.Contracts;
    using Models;
    using Utilities;
    using Views;

    public abstract class Controller
    {
        private const string Auth = "auth";

        protected Controller()
        {
            this.Model = new ViewModel();
            this.ModelState = new Model();
            this.Response = new HttpResponse(HttpResponseStatusCode.Ok);
        }

        public IHttpRequest Request { get; set; }

        public IHttpResponse Response { get; set; }

        protected ViewModel Model { get; }

        public Model ModelState { get; }

        // New
        public IIdentity Identity => (IIdentity)this.Request.Session.GetParameter(Auth);

        protected IViewable View([CallerMemberName] string caller = "")
        {
            var controllerName = ControllerUtilities.GetControllerName(this);

            var fullyQualifiedName = ControllerUtilities.GetViewFullQualifiedName(controllerName, caller);

            var view = new View(fullyQualifiedName, this.Model.Data);

            return new ViewResult(view);
        }

        protected IRedirectable RedirectToAction(string redirectUrl)
        {
            return new RedirectResult(redirectUrl);
        }

        protected bool IsLoggedIn()
        {
            return this.Request.Session.ContainsParameter("username");
        }

        protected void SignInUser(string username, string userCookie)
        {
            this.Request.Session.AddParameter("username", username);
            this.Response.Cookies.Add(new HttpCookie(HttpCookie.Auth, userCookie));
        }

        protected void SignIn(IIdentity auth)
        {
            this.Request.Session.AddParameter(Auth, auth);
        }
         protected void SignOut()
        {
            this.Request.Session.ClearParameters();
        }
    }
}