using System;
using System.Collections.Generic;
using System.Text;


public class Worker : Human
{
    private double workHoursPerDay;
    private decimal weekSalary;


    private double WorkHoursPerDay
    {
        get { return workHoursPerDay; }
        set
        {
            if (value < 1 || value > 12)
            {
                throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
            }
            workHoursPerDay = value;
        }
    }

    private decimal WeekSalary
    {
        get { return weekSalary; }
        set
        {
            if (value < 10)  ///// may be    <=10  ????
            {
                throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
            }
            weekSalary = value;
        }
    }


    public Worker(string firstName, string secondName, decimal weekSalary, double workHoursPerDay)
        : base(firstName, secondName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public override string ToString()
    {
        var salaryPerHour = (WeekSalary / 5) / (decimal)WorkHoursPerDay;
        return $"First Name: {base.FirstName}\nLast Name: {base.LastName}\nWeek Salary: {this.WeekSalary:F2}\nHours per day: {this.WorkHoursPerDay:F2}\nSalary per hour: {salaryPerHour:F2}";
    }
}