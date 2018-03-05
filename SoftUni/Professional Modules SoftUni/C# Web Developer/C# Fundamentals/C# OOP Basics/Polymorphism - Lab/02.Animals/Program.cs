using System;


class Program
{
    static void Main(string[] args)
    {
        Animal cat = new Cat("Pesho", "Felix");
        Animal dog = new Dog("Gosho", "Meat");

        Console.WriteLine(cat.ExplainSelf());
        Console.WriteLine(dog.ExplainSelf());
    }
}