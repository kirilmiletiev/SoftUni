namespace IRunes.App.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;
    using Services;
    using Services.Contracts;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;

    public abstract class Controller
    {
        private const string ControllerSuffixName = "Controller";

        private readonly IUserCookieService userCookieService;

        protected Controller()
        {
            this.userCookieService = new UserCookieServer();
            this.ViewBag = new Dictionary<string, string>();
        }

        public IDictionary<string, string> ViewBag { get; private set; }

        protected IHttpResponse View([CallerMemberName] string viewName = "")
        {
            var path = $"../../../Views/{this.GetController()}/{viewName}.html";

            if (!File.Exists(path))
            {
                return new BadRequestResult(HttpResponseStatusCode.NotFound);
            }

            var content = File.ReadAllText(path);
            foreach (var key in this.ViewBag.Keys)
            {
                if (content.Contains($"{{{{{key}}}}}"))
                {
                    content = content.Replace($"{{{{{key}}}}}", this.ViewBag[key]);
                }
            }

            return new HtmlResult(content, HttpResponseStatusCode.Ok);
        }

        protected void SignInUser(string username, IHttpRequest request, IHttpResponse response)
        {
            request.Session.AddParameter("username", username);
            var userCookie = this.userCookieService.GetUserCookie(username);
            response.Cookies.Add(new HttpCookie(".auth-irunes", userCookie));
        }

        protected bool IsAuthenticated(IHttpRequest request)
        {
            return request.Session.ContainsParameter("username");
        }

        protected void ApplyError(string errorMessage)
        {
            this.ViewBag["showError"] = "block";
            this.ViewBag["error"] = errorMessage;
        }

        protected void SetViewBagData()
        {
            this.ViewBag["showError"] = "none";
        }

        private string GetController()
        {
            var controllerName = this.GetType().Name.Replace(ControllerSuffixName, string.Empty);
            return controllerName;
        }
    }
}