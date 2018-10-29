using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            // var parkPlatz = new SortedSet<string>();
            var parkPlatz = new List<string>();
            var input = Console.ReadLine();

            while (input != "END")
            {
                var splittedInput = Regex.Split(input, ", ");
                var command = splittedInput[0];
                var nummer = splittedInput[1];

                if (command == "IN")
                {
                    parkPlatz.Add(nummer);
                }
                else if(command == "OUT")
                {
                    parkPlatz.Remove(nummer);
                }

                input = Console.ReadLine();
            }

            if (parkPlatz.Count > 0)
            {
                foreach (var car in parkPlatz.OrderByDescending(x=>x).Reverse())
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
