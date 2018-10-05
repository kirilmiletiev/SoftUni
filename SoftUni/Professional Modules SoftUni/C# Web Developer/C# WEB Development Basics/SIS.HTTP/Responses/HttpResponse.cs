namespace SIS.HTTP.Responses
{
    using System.Linq;
    using System.Text;
    using Common;
    using Contracts;
    using Enums;
    using Extensions;
    using Headers;
    using Headers.Contracts;
    using SIS.HTTP.Cookies;
    using SIS.HTTP.Cookies.Contracts;

    public class HttpResponse : IHttpResponse
    {
        public HttpResponse()
        {
        }

        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
            this.StatusCode = statusCode;

            this.Cookies = new HttpCookieCollection();
        }

        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; private set; }

        public byte[] Content { get; set; }

        public IHttpCookieCollection Cookies { get; private set; }


        public void AddCookie(HttpCookie cookie)
        {

            this.Cookies.Add(cookie);
        }


        public void AddHeader(HttpHeader header)
        {
            this.Headers.Add(header);
        }

        public byte[] GetBytes()
        {
            return Encoding.UTF8.GetBytes(this.ToString()).Concat(this.Content).ToArray();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}")
                .AppendLine(this.Headers.ToString());
                //.AppendLine();   <<<--- Докато разбера че този ред чупи всичко... един час през дебъгер ;(

            //// SET COOKIE HEADER
            if (this.Cookies.HasCookies())
            {
                sb.AppendLine($"Set-Cookie: {this.Cookies}");
            }
            sb.AppendLine();

            return sb.ToString();

           
        }
    }
}