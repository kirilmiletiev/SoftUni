using System;
using System.Collections.Generic;

namespace _10.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TupleValuePair<object>> list = new List<TupleValuePair<object>>();


            var firstLine = Console.ReadLine().Split();
            list.Add(new TupleValuePair<object>(firstLine[0] + " " + firstLine[1], firstLine[2]));

            var secondLine = Console.ReadLine().Split();
            list.Add(new TupleValuePair<object>(secondLine[0], int.Parse(secondLine[1])));

            var thirdLine = Console.ReadLine().Split();
            list.Add(new TupleValuePair<object>(int.Parse(thirdLine[0]), double.Parse(thirdLine[1])));


            foreach (TupleValuePair<object> pair in list)
            {
                Console.WriteLine(pair);
            }

        }
    }
}
