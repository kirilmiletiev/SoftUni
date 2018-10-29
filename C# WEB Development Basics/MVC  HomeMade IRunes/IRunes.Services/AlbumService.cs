namespace IRunes.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Data;
    using Models;

    public class AlbumService : IAlbumService
    {
        private const decimal Discount = 0.13m;

        public Album GetAlbum(int id)
        {
            using (var context = new IRunesDbContext())
            {
                var album = context
                    .Albums
                    .Find(id);

                return album;
            }
        }

        public bool ContainsAlbum(string name)
        {
            using (var context = new IRunesDbContext())
            {
                var isExist = context
                    .Albums
                    .Any(a => a.Name == name);

                return isExist;
            }
        }

        public void AddAlbum(string name, string cover)
        {
            using (var context = new IRunesDbContext())
            {
                var album = new Album()
                {
                    Name = name,
                    Cover = cover
                };

                context.Albums.Add(album);
                context.SaveChanges();
            }
        }

        public List<Album> GetAllAlbums()
        {
            using (var context = new IRunesDbContext())
            {
                var allAlbums = context.Albums.ToList();

                return allAlbums;
            }
        }

        public decimal GetTotalPrice(int id)
        {
            using (var context = new IRunesDbContext())
            {
                var totalPrice = context
                    .Tracks
                    .Where(t => t.AlbumId == id)
                    .Sum(t => (t.Price - t.Price * Discount));

                return totalPrice;
            }
        }
    }
}