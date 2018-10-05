namespace SIS.HTTP.Responses.Contracts
{
    using Enums;
    using Headers;
    using Headers.Contracts;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Cookies.Contracts;

    public interface IHttpResponse
    {
        HttpResponseStatusCode StatusCode { get; set; }

        IHttpHeaderCollection Headers { get; }

        IHttpCookieCollection Cookies { get; }

        byte[] Content { get; set; }

        void AddHeader(HttpHeader header);

        byte[] GetBytes();

        void AddCookie(HttpCookie cookie);
    }
}