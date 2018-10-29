using System;
using System.Collections.Generic;
using System.Text;

namespace EventImplementation.Models
{
    public class NameChangeEventArgs : EventArgs
    {
        public NameChangeEventArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
