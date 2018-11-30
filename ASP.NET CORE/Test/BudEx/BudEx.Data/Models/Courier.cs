using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BudEx.Data.Models.Enums;

namespace BudEx.Data.Models
{
    public class Courier
    {
        public Courier()
        {
            this.TodayShipments = new List<BudExUserPacket>();

            this.AllTimeShipments = new List<BudExUserPacket>();

            this.StartDate = DateTime.UtcNow;

            this.Level = Level = CourierLevel.Bunny;

            this.IsStillWork = true;
        }

        public Courier(string firstName, string lastName, string phoneNumber)
        : this()
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }



        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3), MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3), MaxLength(50)]
        public string LastName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public List<BudExUserPacket> TodayShipments { get; set; } //virtual

        public List<BudExUserPacket> AllTimeShipments { get; set; } // virtual/?

        [Required]
        public CourierLevel Level { get; set; }

        public bool IsStillWork { get; set; }
    }
}
