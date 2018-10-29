namespace IRunes.Services.Contracts
{
    using System.Collections.Generic;
    using Models;

    public interface ITrackService
    {
        void AddTrack(string name, string link, decimal price, int albumId);

        bool ContainsTrack(string name);

        Track GetTrack(int trackId);

        List<Track> GetAllTracks(int albumId);
    }
}