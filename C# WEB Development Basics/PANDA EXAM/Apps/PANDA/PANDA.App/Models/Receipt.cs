using System;

namespace PANDA.App.Models
{
    public class Receipt
    {
        public int Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn  { get; set; }

        public User Recipient { get; set; }

        public Package Package { get; set; }
    }
}
