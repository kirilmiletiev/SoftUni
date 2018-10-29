namespace IRunes.App.Extensions
{
    using System.Net;

    public static class StringExtensions
    {
        public static string UrlDecode(this string text)
        {
            return WebUtility.UrlDecode(text);
        }
    }
}