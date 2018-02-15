using System;

namespace _03.OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine().Split();
                var name = data[0];
                var age = int.Parse(data[1]);

                var chovek = new Person(name, age);
                Family.AddMember(chovek);
                //if (!Family.persons.Contains(chovek))
                //{
                //    Family.persons.Add(chovek);
                //}
            }
            Family.GetOldestMember();
        }
    }
}
