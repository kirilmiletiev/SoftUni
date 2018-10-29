using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Validate_URL
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputUrl = WebUtility.UrlDecode(Console.ReadLine());

            string result = ValidateUrl(inputUrl);

            Console.WriteLine(result);

        }

        private static string ValidateUrl(string inputUrl)
        {


            Uri uri = null;
            if (!Uri.TryCreate(inputUrl, UriKind.Absolute, out uri) || null == uri)
            {
                return "Invalid URL";
            }

            if (!uri.IsDefaultPort)
            {
                return "Invalid URL";
            }

            string protocol = uri.Scheme;
            string host = uri.Host;
            int port = uri.Port;
            string path = uri.LocalPath;
            string query = uri.Query;
            string fragment = uri.Fragment;

            if (protocol.Equals("") || host.Equals(""))
            {
                return "Invalid URL";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Protocol: {protocol}")
                .AppendLine($"Host: {host}");

            if (port.Equals(""))
            {
                if (protocol.Equals("Http"))
                {
                    port = 80;
                }
                else
                {
                    port = 443;
                }
            }
            sb.AppendLine($"Port: {port}");
            if (path.Equals(""))
            {
                path = "/";
            }
            sb.AppendLine($"Path: {path}");

            if (!query.Equals(""))
            {
                sb.AppendLine($"Query: {query.Trim('?')}");
            }
            if (!fragment.Equals(""))
            {
                sb.AppendLine($"Fragment: {fragment.Trim('#')}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
