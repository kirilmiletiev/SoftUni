using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FedEx.Data.Models
{
    public class Sender : FedExUser
    {
        public Sender()
        {
            base.Packets = new List<Packet>();
        }

        public Sender(string address)
        :base(address)
        {
        }
    }
}
