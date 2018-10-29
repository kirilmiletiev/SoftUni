using System;

class Program
{
    static void Main(string[] args)
    {
        var input = Console.ReadLine().Split();

        if (input.Length == 4)
        {
            var pricePerD = decimal.Parse(input[0]);
            var allDays = int.Parse(input[1]);
            var season = input[2];
            var disc = input[3];
            PriceCalculator price = new PriceCalculator(pricePerD, allDays, season, disc);
        }
        else
        {
            var pricePerD = decimal.Parse(input[0]);
            var allDays = int.Parse(input[1]);
            var season = input[2];
            PriceCalculator price = new PriceCalculator(pricePerD, allDays, season);
        }

    }
}