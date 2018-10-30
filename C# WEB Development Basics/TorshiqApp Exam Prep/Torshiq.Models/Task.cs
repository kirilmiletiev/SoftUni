using System;
using System.Collections;
using System.Collections.Generic;

namespace Torshiq.Models
{
    public class Task : BaseEntity
    {
        public Task()
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
