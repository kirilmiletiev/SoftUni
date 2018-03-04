using System;
using System.Collections.Generic;
using System.Text;


class Pet : IBirthdate
{
    private string name;
    private string birthdate;

    public Pet(string name, string birthdate)
    {
        this.Name = name;
        this.Birthdate = birthdate;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Birthdate
    {
        get { return birthdate; }
        set { birthdate = value; }
    }
}