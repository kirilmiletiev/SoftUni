using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            var NumbersOfCars = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();

            var input = Console.ReadLine();
            int counter = 0;

            while (input != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < NumbersOfCars; i++)
                    {
                        if (queue.Count>0)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            counter++;
                        }
                        
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }

                input = Console.ReadLine();

            }
            Console.WriteLine($"{counter} cars passed the crossroads.");
        }
    }
}
