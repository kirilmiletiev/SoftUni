using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]> pompa = new Queue<int[]>();

            for (int i = 0; i < n; i++)
            {
                pompa.Enqueue(Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray());
            }

            var truckFuel = 0;
            var startIndex = 0;
            var loopBottom = pompa.Count;

            for (int i = 0; i <= loopBottom && startIndex < pompa.Count; i++)
            {
                var currentPump = pompa.Dequeue();
                pompa.Enqueue(currentPump);
                truckFuel += currentPump[0] - currentPump[1];

                if (truckFuel < 0)
                {
                    startIndex = i + 1;
                    loopBottom += pompa.Count;
                    truckFuel = 0;
                }
            }

            Console.WriteLine(startIndex);
        }
    }
}
