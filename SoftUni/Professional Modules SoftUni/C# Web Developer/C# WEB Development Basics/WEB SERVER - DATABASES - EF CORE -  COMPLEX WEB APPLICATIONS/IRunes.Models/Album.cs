namespace IRunes.Models
{
    using System.Collections.Generic;

    public class Album : BaseModel<int>
    {
        public Album()
        {
            this.Tracks = new HashSet<Track>();
        }


        public int Id { get; set; }

        public string Name { get; set; }

        public string Cover { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
