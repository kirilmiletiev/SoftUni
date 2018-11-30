using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;
using System.Xml;
using BudEx.Data.Models.Enums;

namespace BudEx.Data.Models
{
    public class Packet : IPacket
    {
        public Packet() { }

        public Packet(BudExUser sender, BudExUser recipient, string description, double weight, decimal price)
        : this()
        {
            this.Sender = sender;
            this.Recipient = recipient;
            this.Description = description;
            this.Weight = weight;
            this.Price = price;

            this.Status = ShipmentStatus.Pending;
            this.IsTheShipmentPaid = false;

            //TODO: Find a way to sort packets to different courier.  :: Admin will see all pending packages and "sent" them to courier for the region/ or automatic sorting algorithm.(By regions or by ID )
        }

        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public BudExUser Sender { get; set; }

        [Required]
        public BudExUser Recipient { get; set; }

        public Courier Courier { get; set; }

        public ShipmentStatus Status { get; set; }

        public string Description { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public decimal Price { get; set; }
        
        public bool IsTheShipmentPaid { get; set; }
    }
}
