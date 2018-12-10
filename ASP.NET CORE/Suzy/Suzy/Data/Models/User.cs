using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Suzy.Data.Models.Enums;

namespace Suzy.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Packages = new List<Package>();

            this.CustomRole = CustomRole.Customer;
        }
        public int Age { get; set; }

        public string Description { get; set; }

        public CustomRole CustomRole { get; set; }

        public ICollection<Package> Packages { get; set; }

    }
}
