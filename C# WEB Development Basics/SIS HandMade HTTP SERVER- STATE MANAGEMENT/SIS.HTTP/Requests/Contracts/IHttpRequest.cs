namespace SIS.HTTP.Requests.Contracts
{
    using System.Collections.Generic;
    using Enums;
    using Headers.Contracts;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Cookies.Contracts;
    using SIS.HTTP.Sessions.Contracts;

    public interface IHttpRequest
    {
        string Path { get; }

        string Url { get; }

        Dictionary<string, object> FormData { get; }

        Dictionary<string, object> QueryData { get; }

        IHttpHeaderCollection Headers { get; }

        HttpRequestMethod RequestMethod { get; }


        IHttpCookieCollection Cookies { get; }

        IHttpSession Session { get; set; }
        
    }
}