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
        private const string RootDirectory = "../../../";
        private const string ViewsFolder = "Views";
        private const string LayoutFile = "_Layout.html";

        private readonly IUserCookieService userCookieService;

        protected Controller()
        {
            this.userCookieService = new UserCookieServer();
            this.ViewBag = new Dictionary<string, string>();
        }

        public Dictionary<string, string> ViewBag { get; private set; }

        protected IHttpResponse View(string viewName, Dictionary<string, string> viewBag)
        {
            var content = this.GetViewContent(viewName, viewBag);
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

        private string GetController()
        {
            var controllerName = this.GetType().Name.Replace(ControllerSuffixName, string.Empty);
            return controllerName;
        }

        private string GetViewContent(string viewName, Dictionary<string, string> viewBag)
        {
            var layoutContent = File.ReadAllText($"{RootDirectory}{ViewsFolder}/{LayoutFile}");
            var viewPath = $"{RootDirectory}{ViewsFolder}/{this.GetController()}/{viewName}.html";
            var viewContent = File.ReadAllText(viewPath);

            if (viewBag.Count != 0)
            {
                foreach (var pair in viewBag)
                {
                    viewContent = viewContent.Replace($"@Model.{pair.Key}", pair.Value);
                }
            }

            var content = layoutContent.Replace("@RenderBody()", viewContent);
            return content;
        }
    }
}