namespace IRunes.App.Controllers
{
    using System.Linq;
    using System.Text;
    using Services.Contracts;
    using SIS.Framework.ActionResults;
    using SIS.Framework.ActionResults.Contracts;
    using SIS.Framework.Attributes.Methods;
    using SIS.Framework.Controllers;
    using SIS.HTTP.Extensions;
    using ViewModels;

    public class AlbumController : Controller
    {
        private const string None = "none";
        private const string Inline = "inline";
        private const string DisplayError = "DisplayError";
        private const string ErrorMessage = "ErrorMessage";
        private const string AllAlbums = "AllAlbums";
        private const string NoAlbums = "There are currently no albums.";
        private const string AlbumNameExists = "Album name already exists!";
        private const string NoTracks = "There are currently no tracks.";

        private readonly IAlbumService albumService;
        private readonly ITrackService trackService;

        public AlbumController(IAlbumService albumService, ITrackService trackService)
        {
            this.albumService = albumService;
            this.trackService = trackService;
        }

        [HttpGet]
        public IActionResult All()
        {
            if (!this.IsLoggedIn())
            {
                return new RedirectResult("/User/Login");
            }

            var allAlbums = this.albumService.GetAllAlbums();
            var sb = new StringBuilder();
            if (allAlbums.Any())
            {
                foreach (var album in allAlbums)
                {
                    var albumText = $@"<div><h4><a href=/Album/Details?id={album.Id}>{album.Name}</a></h4></div><br/>";
                    sb.AppendLine(albumText);
                }

                this.Model.Data[AllAlbums] = sb.ToString();
            }
            else
            {
                this.Model.Data[AllAlbums] = NoAlbums;
            }

            return this.View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (!this.IsLoggedIn())
            {
                return new RedirectResult("/User/Login");
            }

            this.Model.Data[DisplayError] = None;
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(AlbumCreateViewModel model)
        {
            var name = model.Name.UrlDecode();
            var cover = model.Cover.UrlDecode();

            if (this.albumService.ContainsAlbum(name))
            {
                this.Model.Data[DisplayError] = Inline;
                this.Model.Data[ErrorMessage] = AlbumNameExists;
                return this.View();
            }

            this.albumService.AddAlbum(name, cover);
            return new RedirectResult("/Album/All");
        }

        [HttpGet]
        public IActionResult Details()
        {
            if (!this.IsLoggedIn())
            {
                return new RedirectResult("/User/Login");
            }

            if (!this.Request.QueryData.ContainsKey("id"))
            {
                return new RedirectResult("/Album/All");
            }

            var id = int.Parse(this.Request.QueryData["id"].ToString());
            var album = this.albumService.GetAlbum(id);

            if (album == null)
            {
                return new RedirectResult("/Album/All");
            }

            this.Model.Data["Cover"] = album.Cover;
            this.Model.Data["Name"] = album.Name;
            this.Model.Data["Price"] = $"${this.albumService.GetTotalPrice(id):F2}";
            this.Model.Data["AlbumId"] = id;

            var allTracks = this.trackService.GetAllTracks(id);
            var sb = new StringBuilder();
            if (allTracks.Any())
            {
                sb.AppendLine("<ol>");
                foreach (var track in allTracks)
                {
                    sb.AppendLine($"<li><div><a href=/Track/Details?albumId={id}&trackId={track.Id}>{track.Name}</a></div></li>");
                }
                sb.AppendLine("</ol>");
                this.Model.Data["AllTracks"] = sb.ToString();
            }
            else
            {
                this.Model.Data["AllTracks"] = NoTracks;
            }

            return this.View();
        }
    }
}