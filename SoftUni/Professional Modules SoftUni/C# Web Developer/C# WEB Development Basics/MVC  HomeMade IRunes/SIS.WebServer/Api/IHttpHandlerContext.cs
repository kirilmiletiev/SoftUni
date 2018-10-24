namespace SIS.WebServer.Api
{
    using HTTP.Requests.Contracts;
    using HTTP.Responses.Contracts;

    public interface IHttpHandlerContext
    {
        IHttpResponse Handle(IHttpRequest request);
    }
}