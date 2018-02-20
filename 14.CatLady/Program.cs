﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _14.CatLady
{
    class Program
    {
        static void Main(string[] args)
        {
            var cats = GetCats();
            PrintCat(cats);
        }

        private static void PrintCat(Stack<Cat> cats)
        {
            var catToPrint = Console.ReadLine();
            var foundCat = cats.FirstOrDefault(c => c.Name == catToPrint);
            Console.WriteLine(foundCat.ToString());
        }

        private static Stack<Cat> GetCats()
        {
            var cats = new Stack<Cat>();
            var kittyData = Console.ReadLine().Split();

            while (kittyData[0] != "End")
            {
                var breed = kittyData[0];
                var name = kittyData[1];
                var characteristicValue = double.Parse(kittyData[2]);
                cats.Push(new Cat(name, breed, characteristicValue));

                kittyData = Console.ReadLine().Split();
            }

            return cats;
        }
    }
}