using System;
using System.Collections.Generic;

namespace _11.Threeuple
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Threeuple<object>> list = new List<Threeuple<object>>();


            var firstLine = Console.ReadLine().Split();
            if (firstLine.Length == 4)
            {
                //list.Add(new Threeuple<object>(firstLine[0] + " " + firstLine[1], firstLine[2], firstLine[3]));
                list.Add(new Threeuple<object>($"{firstLine[0]} {firstLine[1]}", firstLine[2], firstLine[3]));
            }
            else if (firstLine.Length == 3)
            {
                list.Add(new Threeuple<object>(firstLine[0], firstLine[1], firstLine[2]));
            }


            var secondLine = Console.ReadLine().Split();
            bool IsDrunk = false;
            var drunkOrNot = secondLine[2];
            if (drunkOrNot == "drunk")

            {
                IsDrunk = true;
            }
            list.Add(new Threeuple<object>(secondLine[0], int.Parse(secondLine[1]), IsDrunk.ToString()));

            var thirdLine = Console.ReadLine().Split();
            list.Add(new Threeuple<object>((thirdLine[0]), double.Parse(thirdLine[1]), thirdLine[2]));


            foreach (Threeuple<object> pair in list)
            {
                Console.WriteLine(pair);
            }
        }
    }
}
