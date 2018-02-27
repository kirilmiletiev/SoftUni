using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Student : Human
{
    private string facultyNumber;

    private string FacultyNumber
    {
        get { return facultyNumber; }
        set
        {
            if (value.Length < 5 || value.Length > 10 || !value.All(char.IsLetterOrDigit))
            {
                throw new ArgumentException("Invalid faculty number!");
            }
            facultyNumber = value;
        }
    }

    public Student(string firstName, string lastName, string facultyNumber)
        : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public override string ToString()
    {
        return $"First Name: {base.FirstName}\nLast Name: {base.LastName}\nFaculty number: {this.FacultyNumber}";
    }
}