using System;

namespace _01.ClassBox
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box = new Box(length,width,height);
            box.Area(box);
            //Rectangular Parallelepiped

            //    Volume = lwh
            //Lateral Surface Area = 2lh + 2wh
            //Surface Area = 2lw + 2lh + 2w
        }
    }
}
