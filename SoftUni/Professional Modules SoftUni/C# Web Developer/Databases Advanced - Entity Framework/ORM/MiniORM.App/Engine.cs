using MiniORM.App.Data;
using MiniORM.App.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniORM.App
{
   public class Engine
    {

        public static void Run()
        {
            var connectionString = Configuration.connectionString;

            var context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Gosho",
                LastName = "Inserted",
                DepartmentId = context.Departments.First().Id,
                IsEmployed = true,
            });

            var employee = context.Employees.Last();
            employee.FirstName = "Modified";

            context.SaveChanges();
        }
    }
}
