using System;
using System.Collections.Generic;
using System.Text;


public class TupleValuePair<T>
{
    Tuple<T, T> tuple;
    private T Item1 { get; set; }
    private T Item2 { get; set; }

    public TupleValuePair(T item1, T item2)
    {
        Item1 = item1;
        Item2 = item2;
        this.tuple = new Tuple<T, T>(Item1, Item2);
    }


    public override string ToString()
    {
        return $"{Item1} -> {Item2}";
    }
}