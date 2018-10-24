namespace IRunes.App.Controllers
{
    using Services.Contracts;
    using SIS.Framework.ActionResults;
    using SIS.Framework.ActionResults.Contracts;
    using SIS.Framework.Attributes.Methods;
    using SIS.Framework.Controllers;
    using ViewModels;

    public class TrackController : Controller
    {
        private const string None = "none";
        private const string Inline = "inline";
        private const string DisplayError = "DisplayError";
        private const string ErrorMessage = "ErrorMessage";

        private readonly ITrackService trackService;
        private readonly IAlbumService albumService;

        public TrackController(ITrackService trackService, IAlbumService albumService)
        {
            this.trackService = trackService;
            this.albumService = albumService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (!this.IsLoggedIn())
            {
                return new RedirectResult("/Album/All");
            }

            if (!this.Request.QueryData.ContainsKey("albumId"))
            {
                return new RedirectResult("/Album/All");
            }

            var albumId = int.Parse(this.Request.QueryData["albumId"].ToString());
            var album = this.albumService.GetAlbum(albumId);
            if (album == null)
            {
                return new RedirectResult("/Album/All");
            }

            this.Model.Data[DisplayError] = None;
            this.Model.Data["Action"] = $"/Track/Create?albumId={albumId}";

            return this.View();
        }

        [HttpPost]
        public IActionResult Create(TrackCreateViewModel model)
        {
            return null;
        }
    }
}