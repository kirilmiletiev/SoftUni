using SIS.HTTP.Sessions.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Sessions
{
    public class HttpSession : IHttpSession
    {

        public HttpSession(string id)
        {
            this.Id = id;
            this.parameters = new Dictionary<string, object>();
        }

        public string Id { get; }

        private readonly Dictionary<string, object> parameters;


        public void AddParameter(string name, object parameter)
        {
            this.parameters[name] = parameter;
        }

        public void ClearParameter()
        {
            this.parameters.Clear();
        }

        public bool ContainsParameter(string name)
        {
            return this.parameters.ContainsKey(name);
        }

        public object GetParameter(string name)
        {
            return this.parameters[name];
        }
    }
}
