using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FedEx.Data.Models.Enums;

namespace FedEx.Data.Models
{
    public class Packet
    {
        public Packet()
        {
            
        }
        
        public int Id { get; set; }

        public Sender Sender { get; set; }

        public Recipient Recipient { get; set; }

        public Courier Courier { get; set; }

        public ShipmentStatus Status { get; set; }

        public string Description { get; set; }
        
        public double Weight { get; set; }
        
        public decimal Price { get; set; }

        public bool IsTheShipmentPaid { get; set; }


    }
}
