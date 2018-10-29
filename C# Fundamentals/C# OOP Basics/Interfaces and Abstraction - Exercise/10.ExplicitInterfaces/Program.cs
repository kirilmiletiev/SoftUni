using System;


class Program
{
    static void Main(string[] args)
    {
        var name = Console.ReadLine().Split();

        while (name[0] != "End")
        {
            var human = new Citizen(name[0]);
            Console.WriteLine(((IPerson)human).GetName());
            Console.WriteLine(((IResident)human).GetName());

            name = Console.ReadLine().Split();
        }

    }
}