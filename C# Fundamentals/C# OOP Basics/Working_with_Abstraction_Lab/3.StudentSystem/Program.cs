using System;


class Program
{
    static void Main(string[] args)
    {
        StudentSystem studentSystem = new StudentSystem();
        //string input = Console.ReadLine();
        while (true)
        {
            studentSystem.ParseCommand();
           // input = Console.ReadLine();
        }
    }
}

