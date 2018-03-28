using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using GenericBox;

public class Box<T> where T : IComparable<T>
{
    private T Type { get; set; }


    public Box(T type)
    {
        this.Type = type;
    }
    public Box()
    {
        
    }


    public static int ElementCompare(List<Box<T>> list, T element)
    {
        int result = 0;
        foreach (Box<T> box in list)
        {
            var compare = box.Type.CompareTo(element);
                if (compare > 0)
                {
                    result++;
                }
           
        }
        return result;
    }

    public override string ToString()
    {
        return $"{Type.GetType().FullName}: {Type}";
    }

}
