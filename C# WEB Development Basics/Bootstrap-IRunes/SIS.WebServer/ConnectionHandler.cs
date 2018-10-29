namespace SIS.WebServer
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net.Sockets;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using HTTP.Common;
    using HTTP.Cookies;
    using HTTP.Enums;
    using HTTP.Requests;
    using HTTP.Requests.Contracts;
    using HTTP.Responses;
    using HTTP.Responses.Contracts;
    using HTTP.Sessions;
    using Results;
    using Routing;

    public class ConnectionHandler
    {
        private readonly Socket client;
        private readonly ServerRoutingTable serverRoutingTable;

        public ConnectionHandler(Socket client, ServerRoutingTable serverRoutingTable)
        {
            CoreValidator.ThrowIfNull(client, nameof(client));
            CoreValidator.ThrowIfNull(serverRoutingTable, nameof(serverRoutingTable));

            this.client = client;
            this.serverRoutingTable = serverRoutingTable;
        }

        private async Task<IHttpRequest> ReadRequest()
        {
            var result = new StringBuilder();
            var data = new ArraySegment<byte>(new byte[1024]);

            while (true)
            {
                var numberOfBytesRead = await this.client.ReceiveAsync(data.Array, SocketFlags.None);
                if (numberOfBytesRead == 0)
                {
                    break;
                }

                var byteAsString = Encoding.UTF8.GetString(data.Array, 0, numberOfBytesRead);
                result.Append(byteAsString);
                if (numberOfBytesRead < 1023)
                {
                    break;
                }
            }

            if (result.Length == 0)
            {
                return null;
            }

            return new HttpRequest(result.ToString());
        }

        private IHttpResponse HandleRequest(IHttpRequest httpRequest)
        {
            var isResourceRequest = this.IsResourceRequest(httpRequest);

            if (isResourceRequest)
            {
                return this.HandleRequestResponse(httpRequest.Path);
            }

            if (!this.serverRoutingTable.Routes.ContainsKey(httpRequest.RequestMethod)
                                || !this.serverRoutingTable.Routes[httpRequest.RequestMethod].ContainsKey(httpRequest.Path))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            return this.serverRoutingTable.Routes[httpRequest.RequestMethod][httpRequest.Path].Invoke(httpRequest);
        }

        private IHttpResponse HandleRequestResponse(string httpRequestPath)
        {
            var startNameResourceIndex = httpRequestPath.LastIndexOf("/");
            var requestPathExtension = httpRequestPath.Substring(httpRequestPath.LastIndexOf("."));

            var resourceName = httpRequestPath.Substring(startNameResourceIndex);

            var resourcePath = $"../../../Resources/{requestPathExtension.Substring(1)}{resourceName}";

            if (!File.Exists(resourcePath))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            var fileContent = File.ReadAllBytes(resourcePath);

            return new InlineResourceResult(fileContent, HttpResponseStatusCode.Ok);
        }

        private bool IsResourceRequest(IHttpRequest httpRequest)
        {
            var requestPath = httpRequest.Path;
            if (requestPath.Contains("."))
            {
                var requestPathExtension = requestPath.Substring(requestPath.LastIndexOf("."));
                return GlobalConstans.Extensions.Contains(requestPathExtension);
            }
            return false;
        }


        private async Task PrepareResponse(IHttpResponse httpResponse)
        {
            var byteSegments = httpResponse.GetBytes();
            await this.client.SendAsync(byteSegments, SocketFlags.None);
        }

        public async Task ProcessRequestAsync()
        {
            var httpRequest = await this.ReadRequest();

            if (httpRequest != null)
            {
                var sessionId = this.SetRequestSession(httpRequest);
                var response = this.HandleRequest(httpRequest);

                this.SetResponseSession(response, sessionId);
                await this.PrepareResponse(response);
            }

            this.client.Shutdown(SocketShutdown.Both);
        }

        private string SetRequestSession(IHttpRequest request)
        {
            string sessionId = null;

            if (request.Cookies.ContainsCookie(HttpSessionStorage.SessionCookieKey))
            {
                var cookie = request.Cookies.GetCookie(HttpSessionStorage.SessionCookieKey);
                sessionId = cookie.Value;
                request.Session = HttpSessionStorage.GetSession(sessionId);
            }
            else
            {
                sessionId = Guid.NewGuid().ToString();
                request.Session = HttpSessionStorage.GetSession(sessionId);
            }

            return sessionId;
        }

        private void SetResponseSession(IHttpResponse response, string sessionId)
        {
            if (sessionId != null)
            {
                response.AddCookie(new HttpCookie(HttpSessionStorage.SessionCookieKey, $"{sessionId}; HttpOnly"));
            }
        }
    }
}