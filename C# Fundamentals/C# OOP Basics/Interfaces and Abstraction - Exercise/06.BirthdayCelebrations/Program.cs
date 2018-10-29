using System;
using System.Collections.Generic;


class Program
{
    static void Main(string[] args)
    {
        // List<object> obj = new List<object>();/// try with one list  orrr try with 3 lists!
        List<Citizen> citizens = new List<Citizen>();
        List<Robot> robots = new List<Robot>();
        List<Pet> pets = new List<Pet>();
        var input = Console.ReadLine().Split();
        while (input[0] != "End")
        {
            if (input[0] == "Citizen")
            {
                var citizen = new Citizen(input[1], int.Parse(input[2]), input[3], input[4]);
                citizens.Add(citizen);
            }
            else if (input[0] == "Robot")
            {
                var robot = new Robot(input[1], input[2], string.Empty);
                robots.Add(robot);

            }
            else if (input[0] == "Pet")
            {
                var pet = new Pet(input[1], input[2]);
                pets.Add(pet);
            }
            input = Console.ReadLine().Split();

        }
        var date = Console.ReadLine();

        foreach (Robot robot in robots)
        {
            if (robot.Birthdate.EndsWith(date))
            {
                Console.WriteLine(robot.Birthdate);
            }
        }

        foreach (Citizen citizen in citizens)
        {
            if (citizen.Birthdate.EndsWith(date))
            {
                Console.WriteLine(citizen.Birthdate);
            }
        }

        foreach (Pet pet in pets)
        {
            if (pet.Birthdate.EndsWith(date))
            {
                Console.WriteLine(pet.Birthdate);
            }
        }
    }
}