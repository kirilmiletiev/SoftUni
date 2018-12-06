using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Suzy.Data.Models.Contracts;

namespace Suzy.Data.Models
{
    public class Sender : ISender
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
    }
}
