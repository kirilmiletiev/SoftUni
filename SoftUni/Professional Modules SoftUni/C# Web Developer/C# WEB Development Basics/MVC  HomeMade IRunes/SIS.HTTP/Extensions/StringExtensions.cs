namespace SIS.HTTP.Extensions
{
    using System.Net;

    public static class StringExtensions
    {
        public static string Capitalize(this string message)
        {
            var firstLetter = message[0].ToString().ToUpper();
            var allOther = message.Substring(1).ToLower();

            return $"{firstLetter}{allOther}";
        }

        public static string UrlDecode(this string text)
        {
            return WebUtility.UrlDecode(text);
        }
    }
}