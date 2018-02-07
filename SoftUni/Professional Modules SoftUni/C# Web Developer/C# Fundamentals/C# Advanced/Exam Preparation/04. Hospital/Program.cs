using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Hospital
{
    public class Patient
    {
        public string test { get; set; }
        public string departament;
        public string doctor;
        public string name;
        public int room;
    }
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
            var ъ = Console.ReadLine().Trim();

            while (ъ != "End")
            {

                GetPrint(departaments, doctors, ъ);

                ъ = Console.ReadLine();
            }

        }

        private static void GetPrint(Dictionary<string, List<string>> departaments, Dictionary<string, List<string>> doctors, string ъ)
        {
            var wtf = ъ.Split(' ').ToArray();
            //int num = 0;
            //bool isNum = false;
            //isNum = int.TryParse(wtf[1], out num);



            //if (ъ.Length == 1)
            if(!ъ.Contains(" "))
            {
                foreach (string s in departaments[ъ])
                {
                    Console.WriteLine(s);
                }
                return;
            }
            if ((ъ.Length > 1))
            {
                int num = 0;
                bool isNum = false;
                isNum = int.TryParse(wtf[1], out num);

                if (isNum)
                {
                    foreach (string s in departaments[wtf[0]].Skip(3 * (int.Parse(wtf[1]))).Take(3).OrderBy(x => x)
                        .ToArray())
                    {
                        Console.WriteLine(s);
                    }
                    return;
                }
                if (!isNum)
                {
                    foreach (KeyValuePair<string, List<string>> keyValuePair in doctors)
                    {
                        if (keyValuePair.Key == "ъ")
                        {
                            foreach (string s in keyValuePair.Value.OrderBy(x => x))
                            {
                                Console.WriteLine(s);
                            }
                        }
                    }
                }
            }
        }
    }
}