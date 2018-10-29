namespace SIS.WebServer
{
    using System;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading.Tasks;
    using HTTP.Enums;
    using HTTP.Requests;
    using HTTP.Requests.Contracts;
    using HTTP.Responses;
    using HTTP.Responses.Contracts;
    using Routing;

    public class ConnectionHandler
    {
        private readonly Socket client;
        private readonly ServerRoutingTable serverRoutingTable;

        public ConnectionHandler(Socket client, ServerRoutingTable serverRoutingTable)
        {
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
            if (!this.serverRoutingTable.Routes.ContainsKey(httpRequest.RequestMethod)
                || !this.serverRoutingTable.Routes[httpRequest.RequestMethod].ContainsKey(httpRequest.Path))
            {
                return new HttpResponse(HttpResponseStatusCode.NotFound);
            }

            return this.serverRoutingTable.Routes[httpRequest.RequestMethod][httpRequest.Path].Invoke(httpRequest);
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
                var httpResponse = this.HandleRequest(httpRequest);
                await this.PrepareResponse(httpResponse);
            }

            this.client.Shutdown(SocketShutdown.Both);
        }
    }
}