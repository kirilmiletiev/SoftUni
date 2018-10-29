using System;
using EventImplementation.Models;

namespace _01EventImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var dispatcher = new Dispatcher();
            var handler = new Handler();
            dispatcher.NameChange += handler.OnDispatcherNameChange;

            var name = Console.ReadLine();

            while (!name.Equals("End"))
            {
                dispatcher.Name = name;
                name = Console.ReadLine();
            }
        }
    }
}
