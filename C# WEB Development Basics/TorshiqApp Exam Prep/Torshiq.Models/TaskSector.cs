using Torshiq.Models.Enums;

namespace Torshiq.Models
{
    public class TaskSector : BaseEntity
    {
        public int TaskId { get; set; }
        public Task Task { get; set; }
        
        public Sector Sector { get; set; }
    }
}
