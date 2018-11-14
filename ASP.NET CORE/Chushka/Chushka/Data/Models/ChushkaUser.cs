using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Chushka.Data.Models
{
    public class ChushkaUser : IdentityUser
    {
        public ChushkaUser()
        {
            this.Orders = new List<Order>();
        }

        public string  FullName { get; set; }

        public CustomRole CustomRole { get; set; }

        public bool IsLoggedIn { get; set; }    

        public ICollection<Order> Orders { get; set; }
    }


    /// <summary>
    /// Sorry Jelev... :)
    /// </summary>
    public enum CustomRole
    {
        Admin = 1,
        User = 2
    }
}
