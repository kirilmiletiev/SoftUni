namespace IRunes.App.Controllers
{
    using System.Linq;
    using System.Text;
    using Extensions;
    using Services;
    using Services.Contracts;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;

    public class AlbumsController : Controller
    {
        private const string AlbumExists = "Album already exists!";
        private const string NoAlbums = "There are currently no albums.";
        private const string AlbumDoesNotExist = "Album does not exist!";
        private const string NoTracks = "There are currently no tracks.";

        private readonly IAlbumsService albumsService;
        private readonly ITrackService trackService;

        public AlbumsController()
        {
            this.albumsService = new AlbumsService();
            this.trackService = new TrackService();
        }

        public IHttpResponse All(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult("/users/login");
            }

            var allAlbums = this.albumsService.GetAllAlbums();
            var sb = new StringBuilder();
            if (allAlbums.Any())
            {
                foreach (var album in allAlbums)
                {
                    var albumText = $@"<div><h4><a href=/albums/details?id={album.Id}>{album.Name}</a></h4></div><br/>";
                    sb.AppendLine(albumText);
                }

                this.ViewBag["AllAlbums"] = sb.ToString();
            }
            else
            {
                this.ViewBag["AllAlbums"] = NoAlbums;
            }

            return this.View("all", this.ViewBag);
        }

        public IHttpResponse Create(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult("/users/login");
            }

            return this.View("create", this.ViewBag);
        }

        public IHttpResponse DoCreate(IHttpRequest request)
        {
            var name = request.FormData["name"].ToString().UrlDecode();
            var cover = request.FormData["cover"].ToString().UrlDecode();

            if (this.albumsService.ContainsAlbum(name))
            {
                this.ViewBag["Error"] = AlbumExists;
                this.ViewBag["BackTo"] = $"<a class=\"btn btn-warning btn-lg\" href=\"/albums/create\" role=\"button\">Back To Create Album</a>";
                return this.View("error", this.ViewBag);
            }

            this.albumsService.AddAlbum(name, cover);

            var response = new RedirectResult("/albums/all");
            return response;
        }

        public IHttpResponse Details(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult("/users/login");
            }

            if (!request.QueryData.ContainsKey("id"))
            {
                this.ViewBag["Error"] = AlbumDoesNotExist;
                this.ViewBag["BackTo"] = $"<a class=\"btn btn-success btn-lg\" href=\"/albums/all\" role=\"button\">Back To Albums</a>";
                return this.View("error", this.ViewBag);
            }

            var albumId = int.Parse(request.QueryData["id"].ToString());
            var album = this.albumsService.GetAlbum(albumId);

            if (album == null)
            {
                this.ViewBag["Error"] = AlbumDoesNotExist;
                this.ViewBag["BackTo"] = $"<a class=\"btn btn-success btn-lg\" href=\"/albums/all\" role=\"button\">Back To Albums</a>";
                return this.View("error", this.ViewBag);
            }

            this.ViewBag["Cover"] = $"<img src=\"{album.Cover}\" alt=\"{album.Name}\" class=\"img-fluid\">";
            this.ViewBag["Name"] = album.Name;
            this.ViewBag["Price"] = $"${this.albumsService.GetTotalPrice(albumId):F2}";
            this.ViewBag["CreateTrack"] = $"<a class=\"btn btn-success\" href=\"/tracks/create?albumId={albumId}\" role=\"button\">Create Track</a>";

            var allTracks = this.trackService.GetAllTracks(albumId);
            var sb = new StringBuilder();
            if (allTracks.Any())
            {
                sb.AppendLine("<ol>");
                foreach (var track in allTracks)
                {
                    var trackText = $@"<li><div><a href=/tracks/details?albumId={albumId}&trackId={track.Id}>{track.Name}</a></div></li><br/>";
                    sb.AppendLine(trackText);
                }
                sb.AppendLine("</ol>");

                this.ViewBag["AllTracks"] = sb.ToString();
            }
            else
            {
                this.ViewBag["AllTracks"] = NoTracks;
            }

            return this.View("details", this.ViewBag);
        }
    }
}