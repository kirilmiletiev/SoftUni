using System;
using System.Collections.Generic;
using System.Text;


public class Point
{
    private int x;

    public int X
    {
        get { return x; }
        set { x = value; }
    }

    private int y;

    public int Y
    {
        get { return y; }
        set { y = value; }
    }

    public Point (int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
}

