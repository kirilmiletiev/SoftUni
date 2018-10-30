using SIS.Framework.Api;
using SIS.Framework.Services;
using Torshiq.App.Controllers;

namespace Torshiq.App
{
    public class StartUp : MvcApplication
    {
        public override void ConfigureServices(IDependencyContainer dependencyContainer)
        {
            dependencyContainer.RegisterDependency<HomeController, HomeController>();
            //dependencyContainer.RegisterDependency<UsersController, UsersController>();
            //dependencyContainer.RegisterDependency<TasksController, TasksController>();
            //dependencyContainer.RegisterDependency<ReportersController, ReportersController>();

            //dependencyContainer.RegisterDependency<IUserService, UserService>();
            //dependencyContainer.RegisterDependency<ITaskService, TaskService>();
        }
    }
}
