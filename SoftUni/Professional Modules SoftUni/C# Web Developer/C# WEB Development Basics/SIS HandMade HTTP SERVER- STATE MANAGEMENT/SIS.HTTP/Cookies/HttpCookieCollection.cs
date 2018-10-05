namespace SIS.HTTP.Cookies
{
    using SIS.HTTP.Cookies.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HttpCookieCollection : IHttpCookieCollection
    {
        public HttpCookieCollection()
        {
            this.cookies = new Dictionary<string, HttpCookie>();
        }

        private readonly Dictionary<string, HttpCookie> cookies;


        public void Add(HttpCookie cookie)
        {
            //this.cookies.Add(cookie.Key.ToString(), cookie);  // ??? is this work???
            this.cookies[cookie.Key] = cookie;
        }

        public bool ContainsCookie(string key)
        {
            return this.cookies.ContainsKey(key);
        }

        public HttpCookie GetCookie(string key)
        {
            return this.cookies[key];
        }

        public bool HasCookies()
        {
            return cookies.Any();
        }


        public override string ToString()
        {
            return string.Join("; ", this.cookies.Values);
        }
    }
}
