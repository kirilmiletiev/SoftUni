using BudEx.Data.Models.Enums;

namespace BudEx.Data.Models
{
    public interface IPacket
    {
        Courier Courier { get; set; }
        string Description { get; set; }
        int Id { get; set; }
        bool IsTheShipmentPaid { get; set; }
        decimal Price { get; set; }
        BudExUser Recipient { get; set; }
        BudExUser Sender { get; set; }
        ShipmentStatus Status { get; set; }
        double Weight { get; set; }
    }
}