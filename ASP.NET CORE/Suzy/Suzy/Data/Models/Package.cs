using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Suzy.Data.Models
{
    public class Package 
    {
        public Package()
        {
            this.Description = "";
            this.Weight = 0.0;
            this.IsPackageDelivered = false;
            this.IsPackagePaid = false;
        }

      //TODO: Constructor with Sender and Recipient!

        public int Id { get; set; }

        public Sender Sender { get; set; }

        public Recipient Recipient { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public bool IsPackageDelivered { get; set; }

        public bool IsPackagePaid { get; set; } 
    }
}
