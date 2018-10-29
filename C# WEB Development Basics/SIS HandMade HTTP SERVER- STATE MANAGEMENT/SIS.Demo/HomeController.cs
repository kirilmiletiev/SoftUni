namespace SIS.Demo
{
    using System.IO;
    using HTTP.Enums;
    using HTTP.Responses.Contracts;
    using WebServer.Results;

    public class HomeController
    {
        public IHttpResponse Index()
        {
            string content = "<h1>Hello, world!</h1>";

            return new HtmlResult(content, HttpResponseStatusCode.Ok);
        }
    }
}