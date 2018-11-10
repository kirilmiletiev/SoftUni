using System;

namespace PandaAsp2.Data.Models
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
