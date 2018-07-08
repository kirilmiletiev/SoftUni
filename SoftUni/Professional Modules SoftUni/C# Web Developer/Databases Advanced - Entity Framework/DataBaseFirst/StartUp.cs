using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;

namespace P02_DatabaseFirst
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            ////3.	Employees Full Information ************************************

            //var context = new SoftUniContext();
            //var employees = context.Employees.OrderBy(x => x.EmployeeId).ToArray();

            //foreach (var emp in employees)
            //{
            //    Console.WriteLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:F2}");
            //}





            ////4.	Employees with Salary Over 50 000 ************************************

            //var context = new SoftUniContext();

            //var employees = context.Employees.Where(x => x.Salary > 50000).Select(x => x.FirstName).OrderBy(x => x).ToArray();

            //foreach (var item in employees)
            //{
            //    Console.WriteLine($"{item}");
            //}





            ////5.Employees from Research and Development ************************************

            //var context = new SoftUniContext();
            //var employees = context.Employees
            //                       .Where(x => x.DepartmentId == 6)
            //                       .OrderBy(x=>x.Salary).ThenByDescending(x=>x.FirstName).ToArray();

            //foreach (var emp in employees)
            //{
            //    Console.WriteLine($"{emp.FirstName} {emp.LastName} from Research and Development - ${emp.Salary:F2}");
            //}





            ////6.	Adding a New Address and Updating Employee ************************************


            //var context = new SoftUniContext();
            //var address = new Address()
            //{
            //    TownId = 4,
            //    AddressText = "Vitoshka 15"
            //};

            //Employee employee = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");

            //if (employee.Address == null)
            //{
            //    employee.Address = (address);
            //}

            //context.SaveChanges();

            //var employees = context.Employees
            //    .OrderByDescending(e => e.AddressId)
            //    .Take(10)
            //    .Select(x => x.Address.AddressText)
            //    .ToArray();

            //foreach (var e in employees)
            //{
            //    Console.WriteLine(e);
            //}





            ////7.Employees and Projects

            //using (var db = new SoftUniContext())
            //{
            //    var employees = db.Employees
            //        .Where(e => e.EmployeesProjects.Any(
            //            ep => ep.Project.StartDate.Year >= 2001 &&
            //            ep.Project.StartDate.Year <= 2003))
            //        .Take(30)
            //        .Select(e => new
            //        {
            //            EmployeeName = $"{e.FirstName} {e.LastName}",
            //            ManagerName = $"{e.Manager.FirstName} {e.Manager.LastName}",
            //            Projects = e.EmployeesProjects.Select(ep => new
            //            {
            //                ep.Project.Name,
            //                ep.Project.StartDate,
            //                ep.Project.EndDate
            //            })
            //        })
            //        .ToList();

            //    foreach (var employee in employees)
            //    {
            //        Console.WriteLine($"{employee.EmployeeName} - Manager: {employee.ManagerName}");
            //        foreach (var project in employee.Projects)
            //        {
            //            string startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

            //            string endDate = project.EndDate == null ? "not finished" : project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);

            //            Console.WriteLine($"--{project.Name} - {startDate} - {endDate}");
            //        }
            //    }
            //}








            ////8.Addresses by Town


            //var context = new SoftUniContext();

            //var addresses = context.Addresses
            //         .OrderByDescending(a => a.Employees.Count)
            //         .ThenBy(a => a.Town.Name)
            //         .ThenBy(a => a.AddressText)
            //         .Take(10)
            //         .Select(a => new
            //         {
            //             AddressText = a.AddressText,
            //             TownName = a.Town.Name,
            //             EmployeeCount = a.Employees.Count
            //         })
            //         .ToList();

            //foreach (var address in addresses)
            //{
            //    Console.WriteLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            //}




            ////9. Employee 147 

            //var context = new SoftUniContext();

            //var employee = context.Employees
            //       .Where(e => e.EmployeeId == 147)
            //       .Select(e => new
            //       {
            //           Name = $"{e.FirstName} {e.LastName}",
            //           Job = e.JobTitle,
            //           Project = e.EmployeesProjects.Select(ep => new
            //           {
            //               ep.Project.Name
            //           })
            //       })
            //       .SingleOrDefault();

            //Console.WriteLine($"{employee.Name} - {employee.Job}");

            //foreach (var project in employee.Project.OrderBy(p => p.Name))
            //{
            //    Console.WriteLine($"{project.Name}");
            //}







            ////10.	Departments with More Than 5 Employees 

            //var context = new SoftUniContext();

            //var departments = context.Departments
            //       .Where(d => d.Employees.Count > 5)
            //       .OrderBy(d => d.Employees.Count)
            //       .ThenBy(d => d.Name)
            //       .Select(d => new
            //       {
            //           DepartmentName = d.Name,
            //           ManagerName = $"{d.Manager.FirstName} {d.Manager.LastName}",
            //           Employees = d.Employees.Select(e => new
            //           {
            //               FirstName = e.FirstName,
            //               LastName = e.LastName,
            //               Job = e.JobTitle
            //           })
            //       })
            //       .ToList();

            //foreach (var department in departments)
            //{
            //    Console.WriteLine($"{department.DepartmentName} - {department.ManagerName}");

            //    foreach (var employee in department.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            //    {
            //        Console.WriteLine($"{employee.FirstName} {employee.LastName} - {employee.Job}");
            //    }
            //    Console.WriteLine("----------");
            //}






            ////11.	Find Latest 10 Projects 

            //var context = new SoftUniContext();
            //var projects = context.Projects
            //      .OrderByDescending(p => p.StartDate)
            //      .Take(10)
            //      .Select(p => new
            //      {
            //          p.Name,
            //          p.Description,
            //          StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
            //      })
            //      .ToList();

            //foreach (var project in projects.OrderBy(p => p.Name))
            //{
            //    Console.WriteLine(project.Name);
            //    Console.WriteLine(project.Description);
            //    Console.WriteLine(project.StartDate);
            //}




            ////12.	Increase Salaries 

            //var context = new SoftUniContext();

            //var departmentsToBeIncrease = new List<string> { "Engineering", "Tool Design", "Marketing", "Information Services" };


            //var employees = context.Employees
            //    .Where(e => departmentsToBeIncrease.Contains(e.Department.Name))
            //    .OrderBy(e => e.FirstName)
            //    .ThenBy(e => e.LastName)
            //    .ToList();

            //employees.ForEach(e => e.Salary *= 1.12m);

            //context.SaveChanges();

            //employees.ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})"));





            ////13.	Find Employees by First Name Starting With Sa

            //var context = new SoftUniContext();
            //var employees = context.Employees
            //        .Where(e => e.FirstName.StartsWith("Sa"))
            //        .Select(e => new
            //        {
            //            e.FirstName,
            //            e.LastName,
            //            e.JobTitle,
            //            e.Salary
            //        })
            //        .OrderBy(e => e.FirstName)
            //        .ThenBy(e => e.LastName)
            //        .ToList();

            //employees.ForEach(e => Console.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})"));





            ////14.	Delete Project by Id 


            //var context = new SoftUniContext();

            //var projectToBeDeleted = context.Projects.FirstOrDefault(p => p.ProjectId == 2);

            //context.RemoveRange(context.EmployeesProjects
            //    .Where(ep => ep.ProjectId == 2));
            //context.Remove(projectToBeDeleted);
            //context.SaveChanges();

            //context.Projects
            //    .Select(p => p.Name)
            //    .Take(10)
            //    .ToList()
            //    .ForEach(p => Console.WriteLine($"{p}"));


        }
    }
}
