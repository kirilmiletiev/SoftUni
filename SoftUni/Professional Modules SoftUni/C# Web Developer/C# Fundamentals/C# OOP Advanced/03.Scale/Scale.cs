using System;
using System.Collections.Generic;
using System.Text;


public class Scale<Т> where Т :IComparable<Т>
{
    private Т Left;
    private Т Right;

    public Scale(Т left, Т right)
    {
        this.Left = left;
        this.Right = right;

    }

    public Т GetHeavier()
    {
        var result = this.Left.CompareTo(Right);
        //if (Left.Equals(Right))
        //{
        //    return null;
        //}
        if (result>0)
        {
            return Left;
        }
        else if (result < 0)
        {
            return Right;
        }
        else
        {
            return default(Т);
        }
    }

}