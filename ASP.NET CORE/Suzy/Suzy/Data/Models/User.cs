using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Suzy.Data.Models
{
    public class User : IdentityUser
    {
        public int Age { get; set; }

        public string Description { get; set; }

    }
}
