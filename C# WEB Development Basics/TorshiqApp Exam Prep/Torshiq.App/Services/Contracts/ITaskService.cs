using System;
using Torshiq.Models;

namespace Torshiq.App.Services.Contracts
{
    public interface ITaskService
    {
        Task AddTask(string title, DateTime dueDate, string description, string participants);

        void AddTaskSectors(string sectorCustomers, string sectorMarketing, string sectorFinances, string sectorInternal, string sectorManagement, int taskId);
    }
}
