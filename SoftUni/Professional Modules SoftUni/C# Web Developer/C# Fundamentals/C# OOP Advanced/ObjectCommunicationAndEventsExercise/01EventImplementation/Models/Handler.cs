using System;
using System.Collections.Generic;
using System.Text;

namespace EventImplementation.Models
{
   public class Handler
    {

        public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
        {
            Console.WriteLine($"Dispatcher's name changed to {args.Name}.");
        }
    }
}