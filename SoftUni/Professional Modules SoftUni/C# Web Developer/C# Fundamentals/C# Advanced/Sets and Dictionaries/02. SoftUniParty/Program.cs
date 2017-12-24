using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> normalSet = new HashSet<string>();
            HashSet<string> vipSet = new HashSet<string>();
            var input = Console.ReadLine();

            while (input != "PARTY")
            {

                foreach (char ch in input)
                {
                    if (char.IsDigit(ch))
                    {
                        vipSet.Add(input);
                        break;
                    }
                    else
                    {
                        normalSet.Add(input);
                        break;
                    }
                }
                
                input = Console.ReadLine();
            }

            var secondInput = Console.ReadLine();
            while (secondInput!= "END")
            {
                if (vipSet.Contains(secondInput))
                {
                    vipSet.Remove(secondInput);
                }

                if (normalSet.Contains(secondInput))
                {
                    normalSet.Remove(secondInput);
                }
                secondInput = Console.ReadLine();
            }

            var nummmm = normalSet.Count + vipSet.Count;


            Console.WriteLine($"{nummmm}");

           // Console.WriteLine("---------------------VIP-----------");
            foreach (var key in vipSet.OrderBy(x=>x))
            {

                Console.WriteLine(key);
            }

            //Console.WriteLine("---------------------NORMAL-----------");
            foreach (var key in normalSet.OrderBy(x=>x))
            {
                Console.WriteLine(key);
            }
            
        }
    }
}
