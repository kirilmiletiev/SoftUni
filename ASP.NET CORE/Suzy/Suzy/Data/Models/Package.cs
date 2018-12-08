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

        public Package(Sender sender, Recipient recipient)
        :this()
        {
            Sender = sender;
            Recipient = recipient;
        }

        public int Id { get; set; }

        public Sender Sender { get; set; }

        public Recipient Recipient { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public bool IsPackageDelivered { get; set; }

        public bool IsPackagePaid { get; set; }


        public User User { get; set; }

        //public Courier Courier { get; set; }
    }
}
