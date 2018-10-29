namespace IRunes.App
{
    using Controllers;
    using Services;
    using Services.Contracts;
    using SIS.Framework;
    using SIS.Framework.Routers;
    using SIS.Framework.Services;
    using SIS.Framework.Services.Contracts;
    using SIS.WebServer;
    using SIS.WebServer.Api;

    public class Launcher
    {
        public static void Main()
        {
            var services = ConfigureServices();

            var handlers = new HttpHandlerContextRouter(new ControllerRouter(services), new ResourceRouter());
            var server = new Server(8080, handlers);

            MvcEngine.Run(server);  
        }

        private static IDependencyContainer ConfigureServices()
        {
            var services = new DependencyContainer();

            services.RegisterDependency<IHttpHandler, ControllerRouter>();
            services.RegisterDependency<HomeController, HomeController>();
            services.RegisterDependency<UserController, UserController>();
            services.RegisterDependency<AlbumController, AlbumController>();
            services.RegisterDependency<TrackService, TrackService>();

            services.RegisterDependency<IUserCookieService, UserCookieService>();
            services.RegisterDependency<IUserService, UserService>();
            services.RegisterDependency<IHashService, HashService>();
            services.RegisterDependency<IAlbumService, AlbumService>();
            services.RegisterDependency<ITrackService, TrackService>();

            return services;
        }
    }
}