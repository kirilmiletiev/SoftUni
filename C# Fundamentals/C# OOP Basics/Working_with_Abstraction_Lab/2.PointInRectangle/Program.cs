using System;
using System.Linq;

namespace _2.PointInRectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            var coordinats = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var topPoint = new Point(coordinats[0], coordinats[1]);
            var bottomPoint = new Point(coordinats[2], coordinats[3]);
            var rectangle = new Rectangle(topPoint,bottomPoint);

            int numOfPoints = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfPoints; i++)
            {
                var currentPoint = Console.ReadLine().Split().Select(int.Parse).ToArray();
                Point point = new Point(currentPoint[0], currentPoint[1]);
                rectangle.Contains(point);
            }




        }
    }
}
