namespace IRunes.Models
{
    public class Track : BaseModel<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public decimal Price { get; set; }

        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }
    }
}