namespace SIS.Demo
{
    using HTTP.Enums;
    using WebServer;
    using WebServer.Routing;

    public class StartUp
    {
        public static void Main()
        {
            var serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request => new HomeController().Index();

            var server = new Server(8000, serverRoutingTable);
            server.Run();
        }
    }
}