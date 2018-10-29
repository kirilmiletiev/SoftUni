namespace SIS.FrameworkDemo
{
    using Framework;
    using Framework.Routers;
    using WebServer;

    public class Launcher
    {
        public static void Main()
        {
            var server = new Server(8000, new ControllerRouter());

            MvcEngine.Run(server);
        }
    }
}