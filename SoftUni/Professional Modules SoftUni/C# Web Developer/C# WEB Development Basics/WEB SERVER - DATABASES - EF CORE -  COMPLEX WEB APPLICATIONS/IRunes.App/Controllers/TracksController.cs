namespace IRunes.App.Controllers
{
    using System.Web;
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

            this.ViewBag["albumId"] = request.QueryData["albumId"].ToString();
            this.SetViewBagData();
            return this.View();
        }

        public IHttpResponse DoCreate(IHttpRequest request)
        {
            if (!this.IsAuthenticated(request))
            {
                return new RedirectResult("/users/login");
            }

            if (!request.QueryData.ContainsKey("albumId"))
            {
                this.ApplyError(AlbumDoesNotExist);
                return new RedirectResult("/albums/all");
            }

            var albumId = int.Parse(request.QueryData["albumId"].ToString());
            var album = this.albumsService.GetAlbum(albumId);

            if (album == null)
            {
                this.ApplyError(AlbumDoesNotExist);
                return new BadRequestResult(HttpResponseStatusCode.NotFound);
            }

            var name = request.FormData["name"].ToString();
            var link = request.FormData["link"].ToString();
            var price = decimal.Parse(request.FormData["price"].ToString());

            var nameDecode = HttpUtility.UrlDecode(name);
            var linkDecode = HttpUtility.UrlDecode(link);

            if (nameDecode.Length <= 2 || linkDecode.Length <= 1 || price <= 0)
            {
                this.ApplyError(InvalidData);
                return this.View();
            }

            if (this.trackService.ContainsTrack(nameDecode))
            {
                this.ApplyError(TrackAlreadyExists);
                return this.View();
            }

            this.trackService.AddTrack(nameDecode, linkDecode, price, albumId);

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
                this.ApplyError(AlbumDoesNotExist);
                return new RedirectResult("/albums/all");
            }

            var albumId = int.Parse(request.QueryData["albumId"].ToString());
            var trackId = int.Parse(request.QueryData["trackId"].ToString());

            var track = this.trackService.GetTrack(trackId);

            if (track == null)
            {
                this.ApplyError(TrackDoesNotExist);
                return new BadRequestResult(HttpResponseStatusCode.NotFound);
            }

            this.ViewBag["name"] = track.Name;
            this.ViewBag["price"] = $"${track.Price}";
            this.ViewBag["albumId"] = albumId.ToString();
            this.ViewBag["link"] = track.Link;

            return this.View();
        }
    }
}