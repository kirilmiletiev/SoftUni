using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chushka.Data.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ClientId { get; set; }
        public ChushkaUser Client { get; set; }

        public DateTime OrderedOn { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; } = false;
    }
}
