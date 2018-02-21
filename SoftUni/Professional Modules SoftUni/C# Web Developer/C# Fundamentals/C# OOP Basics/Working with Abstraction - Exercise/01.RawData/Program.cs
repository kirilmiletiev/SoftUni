using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            string[] parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Cargo cargo = new Cargo(int.Parse(parameters[3]), parameters[4]);
            Engine engine = new Engine(int.Parse(parameters[1]), int.Parse(parameters[2]));
            var tires = new Tire[]
            {
                new Tire(int.Parse(parameters[6]), double.Parse(parameters[5])),
                new Tire(int.Parse(parameters[8]), double.Parse(parameters[7])),
                new Tire(int.Parse(parameters[10]), double.Parse(parameters[9])),
                new Tire(int.Parse(parameters[12]), double.Parse(parameters[11]))
            };

            cars.Add(new Car(parameters[0], cargo,engine,tires));

        }
        PrintCars(cars);
    }

    private static void PrintCars(List<Car> cars)
    {
        var command = Console.ReadLine();

        Console.WriteLine(string.Join(Environment.NewLine, cars
            .Where(c => c.Cargo.Type == command && command == "fragile"
                ? c.Tires
                      .Where(t => t.Pressure < 1)
                      .FirstOrDefault() != null
                : c.Engine.Power > 250)
            .Select(c => c.Model)));
    }
}