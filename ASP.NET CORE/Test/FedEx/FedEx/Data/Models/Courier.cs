using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FedEx.Data.Models.Enums;

namespace FedEx.Data.Models
{
    public class Courier
    {
        public Courier()
        {
            this.StartDate = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string PhoneNumber { get; set; }
        
        public DateTime StartDate { get; set; }

      //  public DateTime? EndDate { get; set; }

       // public List<Packet> TodayShipments { get; set; } //virtual

        //public List<BudExUserPacket> AllTimeShipments { get; set; } // virtual/?
        
        public CourierLevel Level { get; set; }

        public bool IsStillWork { get; set; }
    }
}