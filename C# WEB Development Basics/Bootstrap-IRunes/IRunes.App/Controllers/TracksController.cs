namespace IRunes.App.Controllers
{
    using Extensions;
    using Services;
    using Services.Contracts;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Requests.Contracts;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Results;

    public class TracksController : Controller
    {
        private const string AlbumDoesNotExist = "Album does not exist!";
        private const string InvalidData = "Invalid data!";
        private const string TrackAlreadyExists = "Track already exists!";
        private const string TrackDoesNotExist = "Track does not exist!";

        private readonly IAlbumsService albumsService;
        private readonly ITrackService trackService;

        public TracksController()
        {
            this.albumsService = new AlbumsService();
            this.trackService = new TrackService();
        }

        public IHttpResponse Create(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult("/users/login");
            }

            if (!request.QueryData.ContainsKey("albumId"))
            {
                return new RedirectResult("/albums/all");
            }

            var albumId = request.QueryData["albumId"].ToString();
            this.ViewBag["StartForm"] = $"<form method=\"post\" action=\"/tracks/create?albumId={albumId}\">";
            this.ViewBag["EndForm"] = "</form>";

            return this.View("create", this.ViewBag);
        }

        public IHttpResponse DoCreate(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult("/users/login");
            }

            if (!request.QueryData.ContainsKey("albumId"))
            {
                this.ViewBag["Error"] = AlbumDoesNotExist;
                this.ViewBag["BackTo"] = $"<a class=\"btn btn-warning btn-lg\" href=\"/albums/all\" role=\"button\">Back To Albums</a>";
                return this.View("error", this.ViewBag);
            }

            var albumId = int.Parse(request.QueryData["albumId"].ToString());
            var album = this.albumsService.GetAlbum(albumId);

            if (album == null)
            {
                this.ViewBag["Error"] = AlbumDoesNotExist;
                this.ViewBag["BackTo"] = $"<a class=\"btn btn-warning btn-lg\" href=\"/tracks/create?albumId={albumId}\" role=\"button\">Back To Create Track</a>";
                return this.View("error", this.ViewBag);
            }

            var name = request.FormData["name"].ToString().UrlDecode();
            var link = request.FormData["link"].ToString().UrlDecode();
            var price = decimal.Parse(request.FormData["price"].ToString());


            if (name.Length <= 2 || link.Length <= 1 || price <= 0)
            {
                this.ViewBag["Error"] = InvalidData;
                this.ViewBag["BackTo"] = $"<a class=\"btn btn-warning btn-lg\" href=\"/tracks/create?albumId={albumId}\" role=\"button\">Back To Create Track</a>";
                return this.View("error", this.ViewBag);
            }

            if (this.trackService.ContainsTrack(name))
            {
                this.ViewBag["Error"] = TrackAlreadyExists;
                this.ViewBag["BackTo"] = $"<a class=\"btn btn-warning btn-lg\" href=\"/tracks/create?albumId={albumId}\" role=\"button\">Back To Create Track</a>";
                return this.View("error", this.ViewBag);
            }

            this.trackService.AddTrack(name, link, price, albumId);
            var response = new RedirectResult($"/albums/details?id={albumId}");

            return response;
        }

        public IHttpResponse Details(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult("/users/login");
            }

            if (!request.QueryData.ContainsKey("albumId") || !request.QueryData.ContainsKey("trackId"))
            {
                this.ViewBag["Error"] = AlbumDoesNotExist;
                this.ViewBag["BackTo"] = $"<a class=\"btn btn-warning btn-lg\" href=\"/albums/all\" role=\"button\">Back To Albums</a>";
                return this.View("error", this.ViewBag);
            }

            var albumId = int.Parse(request.QueryData["albumId"].ToString());
            var trackId = int.Parse(request.QueryData["trackId"].ToString());

            var track = this.trackService.GetTrack(trackId);

            if (track == null)
            {
                this.ViewBag["Error"] = TrackDoesNotExist;
                this.ViewBag["BackTo"] = $"<a class=\"btn btn-warning btn-lg\" href=\"/albums/details?id={albumId}\" role=\"button\">Back To Album Details</a>";
                return this.View("error", this.ViewBag);
            }

            this.ViewBag["Name"] = track.Name;
            this.ViewBag["Price"] = $"${track.Price:F2}";
            this.ViewBag["BackTo"] = $"<a class=\"btn btn-warning\" href=\"/albums/details?id={albumId}\" role=\"button\">Back To Album</a>";
            this.ViewBag["Video"] = $"<iframe class=\"embed-responsive-item\" src=\"{track.Link}\"></iframe>";

            return this.View("details", this.ViewBag);
        }
    }
}