using System;
using System.Collections.Generic;
using System.Text;


public class Robot : IControl
{
    private string model;
    private string id;

    public Robot(string model, string id)
    {
        this.model = model;
        this.id = id;
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