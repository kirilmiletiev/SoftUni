using System;
using System.Collections.Generic;
using System.Text;


public class Human
{
    private string firstName;
    private string lastName;


    public string FirstName
    {
        get { return firstName; }
        private set
        {
            foreach (char c in value)
            {
                if (!char.IsUpper(c))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: firstName");
                }
                break;
            }

            if (value.Length < 4)
            {
                throw new ArgumentException("Expected length at least 4 symbols! Argument: firstName");
            }

            firstName = value;
        }
    }

    public string LastName
    {
        get { return lastName; }
        private set
        {
            foreach (char c in value)
            {
                if (!char.IsUpper(c))
                {
                    throw new ArgumentException("Expected upper case letter! Argument: lastName");
                }
                break;
            }

            if (value.Length < 3)
            {
                throw new ArgumentException("Expected length at least 3 symbols! Argument: lastName ");
            }

            lastName = value;
        }
    }

    //public Human()
    //{
    //}

    public Human(string firstName, string secondName)
    //:this()
    {
        this.FirstName = firstName;
        this.LastName = secondName;
    }

    public override string ToString()
    {
        return $"First Name: {this.firstName}\nLast Name: {this.lastName}";
    }
}