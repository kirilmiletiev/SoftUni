using System;
using System.Collections.Generic;
using System.Linq;


public class Program
{
    static void Main(string[] args)
    {
        List<Employee> employeesList = new List<Employee>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split();
            string name = input[0];
            decimal salary = decimal.Parse(input[1]);
            string position = input[2];
            string depart = input[3];
            string email = "n/a";
            int age = -1;
            if (input.Length == 5)
            {
                if (int.TryParse(input[4], out age))
                {
                    age = int.Parse(input[4]);
                }
                else
                {
                    email = input[4];
                    age = -1;

                }
            }
            else if (input.Length == 6)
            {
                if (int.TryParse(input[4], out age))
                {
                    age = int.Parse(input[4]);
                }
                else
                {
                    email = input[4];
                    age = -1;
                }

                if (int.TryParse(input[5], out age))
                {
                    age = int.Parse(input[5]);
                }
                else
                {
                    email = input[5];
                    age = -1;
                }
            }

            Employee employee = new Employee(name, salary, position, depart, email, age);
            employeesList.Add(employee);
        }
        if (employeesList.Count > 0)
        {
            var mostPayableJob = employeesList.GroupBy(d => d.Departm)
                .OrderByDescending(x => x.Select(g => g.Salary).Sum()).First();
            Console.WriteLine($"Highest Average Salary: {mostPayableJob.Key}");

            foreach (Employee employee in mostPayableJob.OrderByDescending(x => x.Salary))
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2} {employee.Email} {employee.Age}");
            }
        }
    }
}

