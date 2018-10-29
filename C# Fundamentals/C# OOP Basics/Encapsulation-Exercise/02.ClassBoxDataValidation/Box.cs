using System;
using System.Collections.Generic;
using System.Text;


public class Box
{
    private double length;
    private double width;
    private double height;

    public double Lenght
    {
        get { return length; }
        private set
        {
            if (value <= 0)
            {
               //Console.WriteLine("Lenght cannot be zero or negative.");
                throw new ArgumentException("Length cannot be zero or negative.");
                
            }
            length = value;
        }
    }


    public double Width
    {
        get { return width; }
        private set
        {
            if (value <= 0)
            {
                //Console.WriteLine("Width cannot be zero or negative.");
                throw new ArgumentException("Width cannot be zero or negative."); 
            }
            width = value;
        }
    }
    

    public double Height
    {
        get { return this.height; }
        private set
        {
            if (value <= 0)
            {
               // Console.WriteLine("Height cannot be zero or negative.");
                throw new ArgumentException("Height cannot be zero or negative."); 
            }

            height = value;
        }
    }

    public Box()
    {
        
    }

    public Box(double lenght, double width, double height)
        :this()
    {
        this.Lenght = lenght;
        this.Width = width;
        this.Height = height;

    }

    public void Area(Box box)
    {
        Console.WriteLine($"Surface Area - {2 * this.length * this.width + 2 * this.length * this.height + 2 * this.width * this.height:f2}\nLateral Surface Area - {(2 * box.Lenght * box.Height) + (2 * box.Width * box.Height):f2}\nVolume - {box.Lenght * box.Width * box.Height:f2}");
        //double volume = box.Lenght * box.Width * box.Height;
        //double lateralSurfaceArea = (2 * box.Lenght * box.Height)+ (2 * box.Width * box.Height);
        //double surfaceArea = (2 * box.Lenght * box.Width) + (2 * box.Lenght * box.Height) + (2 * box.Width);
    }
}