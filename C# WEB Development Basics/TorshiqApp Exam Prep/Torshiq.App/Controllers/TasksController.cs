using SIS.Framework.ActionResults;
using SIS.Framework.Attributes.Method;
using Torshiq.App.Services.Contracts;
using Torshiq.App.ViewModel;

namespace Torshiq.App.Controllers
{
    public class TasksController : BaseController
    {
        private readonly ITaskService taskService;

        public TasksController(ITaskService taskService)
        {
            this.taskService = taskService;
        }


        public IActionResult Create()
        {
            return this.View();
        }


        [HttpPost]
        public IActionResult Create(CreateViewModel model)
        {
            taskService.AddTask(model.Title, model.DueDate, model.Description, model.Participants);
            return this.View();
        }
    }
}
