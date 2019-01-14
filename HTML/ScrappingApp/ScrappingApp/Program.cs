using System;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace ScrappingApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            HtmlDocument doc = new HtmlDocument();
            string url = "https://www.youtube.com/watch?v=Cc5psnYoYIc&t=6795s&index=12&list=PLwp_tTVJjvgfk_TlnnIh9vozIYtdAM3ly";

            var a = GetUrlSourceHtml(url);

            Console.WriteLine(a);
            var b = doc.DetectEncodingHtml(a);
            // WebUtility.;


        }

        public static string GetUrlSourceHtml(string url)
        {
            HtmlDocument htmlDocument = new HtmlDocument();

            HtmlWeb web = new HtmlWeb();
            // web.AutoDetectEncoding = true;
            //  var load = web.Load(url, "Test");
            var doc = web.Load(url);

            var docNode = doc.DocumentNode.InnerHtml;

            WebClient webClient = new WebClient { Encoding = Encoding.UTF8 };

            var data = webClient.DownloadString(url);

            // string s = webClient.Encoding.GetString(data);

           // HtmlNode node = HtmlNode.CreateNode(data.ToString());
            //var html = node.InnerHtml.ToCharArray();

           // string str = Encoding.UTF8.GetString(data, 0, data.Length);

            //object myThing = htmlDocument.LoadHtml(webClient.DownloadString(url));

            return null;
        }
    }
}
