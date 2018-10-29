using System;

namespace _01Stealer
{
    class Program
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            var result = spy.StealFieldInfo("Hacker", "username", "password");

            Console.WriteLine(result);



        }
    }
}
