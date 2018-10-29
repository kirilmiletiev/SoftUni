namespace SIS.HTTP.Headers
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            this.headers[header.Key] = header;
        }

        public bool ContainsHeader(string key)
        {
            return this.headers.ContainsKey(key);
        }

        public HttpHeader GetHeader(string key)
        {
            return this.headers[key];
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.headers);
        }
    }
}