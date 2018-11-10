namespace PandaAsp2.Data.Models
{
    public class PackageReceipt
    {
        public int Id { get; set; }

        public int PackageId { get; set; }
        public Package Package { get; set; }

        public int ReceiptId { get; set; }  
        public Receipt Receipt { get; set; }
    }
}
