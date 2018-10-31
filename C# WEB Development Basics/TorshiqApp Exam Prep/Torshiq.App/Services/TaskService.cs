using System;
using System.Collections.Generic;
using Torshiq.App.Services.Contracts;
using Torshiq.Data;
using Torshiq.Models;
using Torshiq.Models.Enums;

namespace Torshiq.App.Services
{
    public class TaskService : ITaskService
    {
        private readonly TorshiqDbContext context;

        public TaskService(TorshiqDbContext context)
        {
            this.context = context;
        }


        public Task AddTask(string title, DateTime dueDate, string description, string participants)
        {
            var task = new Task()
            {
                Title = title,
                DueDate = dueDate,
                Description = description,
                Participants = participants
            };

            context.Tasks.Add(task);
            context.SaveChanges();

            return task;
        }

        public void AddTaskSectors(string sectorCustomers, string sectorMarketing, string sectorFinances, string sectorInternal,
            string sectorManagement, int taskId)
        {
            var sectors = new List<string>
            {
                sectorCustomers,
                sectorMarketing,
                sectorFinances,
                sectorInternal,
                sectorManagement
            };

            foreach (var sectorString in sectors)
            {
                if (Enum.TryParse<Sector>(sectorString, true, out var sector))
                {
                    var taskSector = new TaskSector
                    {
                        TaskId = taskId,
                        Sector = sector
                    };

                    context.TaskSectors.Add(taskSector);
                    context.SaveChanges();
                }
            }
        }
    }
}

