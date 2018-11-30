using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FedEx.Data.Models
{
    public abstract class FedExUser : IdentityUser
    {
        public FedExUser()
        {
            this.IsDeleted = false;
            this.WhenUserIsRegistered = DateTime.UtcNow;
            this.BonusPoints = 0;

           // this.Packets = new List<Packet>();
        }

        public FedExUser(string address)
        :this()
        {
            this.Address = address;
        }

        public  string Address { get; set; }

        public bool IsDeleted { get; set; }

        public int BonusPoints { get; set; }

        public DateTime WhenUserIsRegistered { get; set; }

        public virtual ICollection<Packet> Packets { get; set; }
    }
}
