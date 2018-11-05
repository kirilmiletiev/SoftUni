using PANDA.App.Controllers;
using PANDA.App.Services.Contracts;
using SIS.Framework.Api;
using SIS.Framework.Services;

namespace PANDA.App
{
    public class StartUp : MvcApplication
    {
        public override void ConfigureServices(IDependencyContainer dependencyContainer)
        {
            dependencyContainer.RegisterDependency<HomeController, HomeController>();
            dependencyContainer.RegisterDependency<UsersController, UsersController>();

            dependencyContainer.RegisterDependency<IUserService, UserService>();

            dependencyContainer.RegisterDependency<ReceiptsController, ReceiptsController>();

            dependencyContainer.RegisterDependency<PackagesController, PackagesController>();

        }
    }
}
