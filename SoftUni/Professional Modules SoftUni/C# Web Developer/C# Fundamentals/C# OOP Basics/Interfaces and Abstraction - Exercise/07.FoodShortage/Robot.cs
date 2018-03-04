using System;
using System.Collections.Generic;
using System.Text;


public class Robot : IControl, IBirthdate
{
    private string model;
    private string id;
    private string birthdate;

    public string Birthdate
    {
        get { return birthdate; }
        set { birthdate = value; }
    }


    public Robot(string model, string id, string birthdate)
    {
        this.Model = model;
        this.Id = id;
        this.Birthdate = birthdate;
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }
}