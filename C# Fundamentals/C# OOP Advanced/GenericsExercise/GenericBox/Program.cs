using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBox
{
    class Program
    {
        static void Main(string[] args)
        {
           List<Box<double>> list = new List<Box<double>>();

            int numberOfCommand = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCommand; i++)
            {
                Box<double> box = new Box<double>((double.Parse(Console.ReadLine())));
                list.Add(box);  
            }

            var element = double.Parse(Console.ReadLine());

            Console.WriteLine( Box<double>.ElementCompare(list, element));
        }
    }
}
