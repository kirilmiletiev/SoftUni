using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using TestRipper;

namespace SandBox
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var url = "https://www.imot.bg/pcgi/imot.cgi?act=5&adv=2c154512205143883"; 

            // var url = "https://www.yavlena.com/87801";
            //string url = "https://www.youtube.com/watch?v=Uyv5pqWxF50&feature=youtu.be";


            ////Make loops over the given URL and if there is a counter, he ++;
            //for (int i = 0; i < 200; i++)
            //{
            //    var result = GetHtml(url);

            //    Console.WriteLine(i);
            //}



            var rawHtmlStr = GetHtml(url);


            List<HtmlRipper> rippers = new List<HtmlRipper>();

            HtmlRipper ripper = new HtmlRipper(){ResultHtml = rawHtmlStr, Url =  url};
            rippers.Add(ripper);


        }
        private static string GetHtml(string url)
        {
            if (url != string.Empty && url != "")
            {
                WebClient webClient = new WebClient();

               if (url.Contains("imot.bg"))
               {
                   webClient.Encoding = Encoding.GetEncoding("windows-1251");

               }

               else if (url.Contains("yavlena"))
               {
                   webClient.Encoding = Encoding.UTF8;
               }

                return webClient.DownloadString(url);
            }
            else
            {
                return null;
            }
        }
    }
}
