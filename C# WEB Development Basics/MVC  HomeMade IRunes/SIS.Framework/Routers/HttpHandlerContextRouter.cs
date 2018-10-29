namespace SIS.Framework.Routers
{
    using System.Linq;
    using HTTP.Common;
    using HTTP.Requests.Contracts;
    using HTTP.Responses.Contracts;
    using WebServer.Api;

    public class HttpHandlerContextRouter : IHttpHandlerContext
    {
        public HttpHandlerContextRouter(IHttpHandler controllerHandler, IHttpHandler resourceRouter)
        {
            this.ControllerHandler = controllerHandler;
            this.ResourceRouter = resourceRouter;
        }

        protected IHttpHandler ControllerHandler { get; }

        protected IHttpHandler ResourceRouter { get; }

        public IHttpResponse Handle(IHttpRequest request)
        {
            if (this.IsResourceRequest(request))
            {
                return this.ResourceRouter.Handle(request);
            }

            return this.ControllerHandler.Handle(request);
        }

        private bool IsResourceRequest(IHttpRequest request)
        {
            var requestPath = request.Path;
            if (requestPath.Contains("."))
            {
                var requestPathExtension = requestPath.Substring(requestPath.LastIndexOf("."));
                return GlobalConstans.ResourceExtensions.Contains(requestPathExtension);
            }
            return false;
        }
    }
}