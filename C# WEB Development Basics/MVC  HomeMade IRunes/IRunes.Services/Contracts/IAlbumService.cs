namespace IRunes.Services.Contracts
{
    using System.Collections.Generic;
    using Models;

    public interface IAlbumService
    {
        Album GetAlbum(int id);

        bool ContainsAlbum(string name);

        void AddAlbum(string name, string cover);

        List<Album> GetAllAlbums();

        decimal GetTotalPrice(int id);
    }
}