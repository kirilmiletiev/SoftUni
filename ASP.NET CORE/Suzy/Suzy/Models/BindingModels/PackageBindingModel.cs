using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Suzy.Data.Models;

namespace Suzy.Models.BindingModels
{
    public class PackageBindingModel
    {
        public PackageBindingModel()
        {
            this.Description = "";
            this.Weight = 0.0;
            //this.IsPackageDelivered = false;
            //this.IsPackagePaid = false;
        }

        public PackageBindingModel(Sender sender, Recipient recipient)
            : this()
        {
           // Sender = sender;
            Recipient = recipient;
        }

        public Recipient Recipient { get; set; }

        public Sender Sender { get; set; }

        //public string FirstName { get; set; }
        //public string LastName { get; set; }

        //public string Address { get; set; }

        //public string SenderPhoneNumber { get; set; } 

        public string Description { get; set; }

        public double Weight { get; set; }
    }
}
