using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FedEx.Data.Models
{
    public class Recipient : FedExUser
    {
        public Recipient()
        {
            base.Packets = new List<Packet>();
        }

        public Recipient(string address)
        :base(address)
        {
        }
    }
}
