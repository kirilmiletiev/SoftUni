using System;
using System.Collections.Generic;
using Torshiq.Models;

namespace Torshiq.App.ViewModel
{
    public class CreateViewModel
    {
        public CreateViewModel()
        {
            this.AffectedSectors = new HashSet<TaskSector>();
        }

        public string Title { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsReported { get; set; }

        public string Description { get; set; }

        public string Participants { get; set; }

        public ICollection<TaskSector> AffectedSectors { get; set; }

    }
}
