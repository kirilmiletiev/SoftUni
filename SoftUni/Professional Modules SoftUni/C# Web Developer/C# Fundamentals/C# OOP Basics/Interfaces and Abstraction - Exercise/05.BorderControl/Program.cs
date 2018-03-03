using System;
using System.Collections.Generic;

namespace _05.BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();
            List<Citizen> citizens = new List<Citizen>();
            List<Robot> robots = new List<Robot>();
            while (input[0] != "End")
            {
                if (input.Length == 3)
                {
                    var citiz = new Citizen(input[0], int.Parse(input[1]), input[2]);
                    citizens.Add(citiz);
                }
                else if (input.Length == 2)
                {
                    var robot = new Robot(input[0], input[1]);
                    robots.Add(robot);
                }
                input = Console.ReadLine().Split();
            }

            var endStr = Console.ReadLine();
            foreach (Robot robot in robots)
            {
                if (robot.Id.EndsWith(endStr))
                {
                    Console.WriteLine(robot.Id);
                }
            }
            foreach (Citizen citizen in citizens)
            {
                if (citizen.Id.EndsWith(endStr))
                {
                    Console.WriteLine(citizen.Id);
                }
            }
        }
    }
}
