using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace TestRipper
{
    public class HtmlRipper
    {

        public HtmlRipper()
        {
        }

            
        public string Url { get; set; }

        public string ResultHtml { get; set; }  



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