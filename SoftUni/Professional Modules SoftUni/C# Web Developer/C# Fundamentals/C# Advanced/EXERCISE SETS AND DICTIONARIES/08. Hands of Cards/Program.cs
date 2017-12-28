using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08.Hands_of_Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            var input = Console.ReadLine();

            while (input != "JOKER")
            {
                var aaa = input.Split(':');
                var spl = input.Split(new[] {' ', ',', ':'});

                var name = spl[0];

                if (!dict.ContainsKey(name))
                {
                    dict.Add(name, aaa[1] );

                }
                else
                {
                    var cards = aaa[1].Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var card in cards)
                    {
                        if (!dict[name].Contains(card))
                        {
                            dict[name] += ", "+card;
                        }
                    }
                    
                    
                }
                input = Console.ReadLine();

            }



            foreach (var value in dict.Values)
            {
                var v = value.Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
               // Console.WriteLine(string.Join(" ", v));

                foreach (var s in v)
                {
                    Console.WriteLine(s);
                }

            }

            //Console.WriteLine("-------------------");

            //foreach (KeyValuePair<string,string> keyValuePair in dict)
            //{
            //    Console.WriteLine(keyValuePair);
            //}


        }
    }
}
