using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> doctors = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> departaments = new Dictionary<string, List<string>>();

            var data = Console.ReadLine();
            while (data != "Output")
            {
                var hospital = data.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var depart = hospital[0];
                var doctor = hospital[1] + " " + hospital[2];
                var patient = hospital[3];
                ///add to departaments DICTIONARY
                /// 
                if (!departaments.ContainsKey(depart))
                {
                    departaments.Add(depart, new List<string>());
                }
                departaments[depart].Add(patient);
                ///add to doctors DICTIONARY
                if (!doctors.ContainsKey(doctor))
                {
                    doctors.Add(doctor, new List<string>());
                }
                doctors[doctor].Add(patient);

                data = Console.ReadLine();
            }
            ////second part (PRINT)
            var whatToPrint = Console.ReadLine().Trim();

            while (whatToPrint != "End")
            {
                var result = whatToPrint.Split();

                if (result.Length == 1)
                {
                    foreach (string s in departaments[whatToPrint])
                    {
                        Console.WriteLine(s);
                    }
                }
                else if (int.TryParse(result[1], out int x))
                {
                    foreach (string s in departaments[result[0]].Skip(3 * (x - 1)).Take(3).OrderBy(p => p))
                    {
                        Console.WriteLine(s);
                    }
                }
                else
                {
                    foreach (string s in doctors[whatToPrint].OrderBy(hm => hm))
                    {
                        Console.WriteLine(s);
                    }
                }
                whatToPrint = Console.ReadLine();
            }
        }
    }
}
