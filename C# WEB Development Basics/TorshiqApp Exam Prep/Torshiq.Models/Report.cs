using System;
using Torshiq.Models.Enums;

namespace Torshiq.Models
{
    public class Report : BaseEntity
    {
        public Status Status { get; set; }

        public DateTime ReportedOn { get; set; }

        public Task Task { get; set; }
        public int TaskId { get; set; }

        public User Reporter { get; set; }
        public int ReporterId { get; set; }

    }
}
