using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BudEx.Data.Models
{
    public class BudExUser : IdentityUser
    {
        public BudExUser()
        {
            this.Packets = new List<BudExUserPacket>();

            this.IsDeleted = false;

            this.BonusPoints = 0;

            this.WhenUserIsRegistered = DateTime.UtcNow;
        }

        public BudExUser(string address) :
            this()
        {
            this.Address = address;
        }
        

        [MinLength(5), MaxLength(200)]
        public string Address { get; set; }

        public  List<BudExUserPacket> Packets { get; set; }

        public int BonusPoints { get; set; }

        public DateTime WhenUserIsRegistered { get; }

        public bool IsDeleted { get; set; }

        //TODO: Implement level of users.


    }
}
