using System;
using System.Linq;
using System.Reflection;

namespace _02.ClassBoxDataValidation
{
    class Program
    {
        static void Main(string[] args)
        {

            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box = new Box();

            try
            {
                box = new Box(length, width, height);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            box.Area(box);
        }
    }
}
