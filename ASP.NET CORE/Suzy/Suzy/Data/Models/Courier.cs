using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Suzy.Data.Models
{
    public class Courier
    {
        public Courier()
        {
            this.Packages = new List<Package>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string PhoneNumber { get; set; }

        public ICollection<Package> Packages { get; set; }
    }
}
