using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BudEx.Data.Models
{
   public class BudExUserPacket
    {
        public int BudExUserId { get; set; }
        public BudExUser BudExUser { get; set; }
        
        public int PacketId { get; set; }
        public Packet Packet { get; set; }
    }
}
