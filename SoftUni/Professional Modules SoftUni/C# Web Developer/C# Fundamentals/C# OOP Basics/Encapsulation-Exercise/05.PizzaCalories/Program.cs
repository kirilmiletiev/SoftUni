using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            int toppicCounter = 0;
            List<Pizza> list = new List<Pizza>();
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var pizzaName = input[1];
            var pizza = new Pizza();
            double total = 0;

            while (input[0] != "END")
            {
                if (input[0] == "Dough")
                {

                    var dought = new Dough(input[1], input[2], double.Parse(input[3]));

                    total += dought.DoughCalories();
                    pizza = new Pizza(pizzaName, dought, new List<Topping>());
                }
                else if (input[0] == "Topping")
                {
                    ////// TOPPING COUNTER BLQK
                    toppicCounter++;
                    if (toppicCounter > 10)
                    {
                        throw new ArgumentException("Number of toppings should be in range [0..10].");
                    }

                    var topping = new Topping(input[1], double.Parse(input[2]));
                    total += topping.BackingTechCallories();
                    pizza.Toppings.Add(topping);
                }

                input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
            list.Add(pizza);

            foreach (Pizza p in list)
            {
                if (string.IsNullOrEmpty(p.Name) || total < 1)
                {
                    return;
                }
                else
                {
                    Console.WriteLine($"{p.Name} - {total:f2} Calories.");
                    //var resu = p.TotalCalories(p);
                    //Console.WriteLine(resu);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            //throw;
         }
    }
}
