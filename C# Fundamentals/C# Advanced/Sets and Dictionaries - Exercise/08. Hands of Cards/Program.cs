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
            var separators = new char []{ ' ', ',' };
            var dict = new Dictionary<string, string>();
            string input = Console.ReadLine();
            while (!input.Equals("JOKER"))
            {
                var nameAndCards = input.Split(':').ToArray();
                string name = nameAndCards[0];
                if (!dict.ContainsKey(name))
                {
                    dict[name] = nameAndCards[1];
                }
                else
                {
                    dict[name] += nameAndCards[1];
                }
                input = Console.ReadLine();
            }
            foreach (var item in dict)
            {
                var CardsList = item.Value.Split(separators, StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();
                int multipl = 1;
                int cardpower = 0;
                long sum=0;
                foreach (var word in CardsList)
                {
                    if (string.Join("",word.Skip(word.Length-1))=="S")
                    {
                        multipl = 4;
                    }
                    else if (string.Join("",word.Skip(word.Length - 1)) == "H")
                    {
                        multipl = 3;
                    }
                    else if (string.Join("", word.Skip(word.Length - 1)) == "D")
                    {
                        multipl = 2;
                    }
                    //-----------------------------------------------------------
                    if (string.Join("",word.Take(word.Length - 1)) == "2")
                    {
                        cardpower = 2;
                    }
                    else if (string.Join("", word.Take(word.Length - 1)) == "3")
                    {
                        cardpower = 3;
                    }
                    else if (string.Join("", word.Take(word.Length - 1)) == "4")
                    {
                        cardpower = 4;
                    }
                    else if (string.Join("", word.Take(word.Length - 1)) == "5")
                    {
                        cardpower = 5;
                    }
                    else if (string.Join("", word.Take(word.Length - 1)) == "6")
                    {
                        cardpower = 6;
                    }
                    else if (string.Join("", word.Take(word.Length - 1)) == "7")
                    {
                        cardpower = 7;
                    }
                    else if (string.Join("", word.Take(word.Length - 1)) == "8")
                    {
                        cardpower = 8;
                    }
                    else if (string.Join("", word.Take(word.Length - 1)) == "9")
                    {
                        cardpower = 9;
                    }
                    else if (string.Join("", word.Take(word.Length - 1)) == "10")
                    {
                        cardpower = 10;
                    }
                    else if (string.Join("", word.Take(word.Length - 1)) == "J")
                    {
                        cardpower = 11;
                    }
                    else if (string.Join("", word.Take(word.Length - 1)) == "Q")
                    {
                        cardpower = 12;
                    }
                    else if (string.Join("", word.Take(word.Length - 1)) == "K")
                    {
                        cardpower = 13;
                    }
                    else if (string.Join("", word.Take(word.Length - 1)) == "A")
                    {
                        cardpower = 14;
                    }
                    sum += cardpower * multipl;
                    cardpower = 0;
                    multipl = 1;
                }
                Console.WriteLine("{0}: {1}", item.Key, sum);
                sum = 0;            
            }

        }
    }
}
