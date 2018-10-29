using System;
using System.Collections.Generic;
using System.Text;


public class Rectangle
{
    private Point topLeft;

    public Point TopLeft
    {
        get { return topLeft; }
        set { topLeft = value; }
    }


    private Point bottomRight;

    public Point BottomRight
    {
        get { return bottomRight; }
        set { bottomRight = value; }
    }

    public Rectangle(Point topLeft, Point bottomRight)
    {
        this.TopLeft = topLeft;
        this.BottomRight = bottomRight;
    }


    public bool Contains(Point point)
    {
        var contains = point.X >= TopLeft.X && point.X <= BottomRight.X &&
                       point.Y >= topLeft.Y && point.Y <= BottomRight.Y;
        Console.WriteLine(contains);
        return contains;
    }

}

