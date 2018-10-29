using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class StackOfStrings
{

    private List<string> List;


   public StackOfStrings()
   {
       this.List = new List<string>();
    }

    public void Push(string item)
    {
        this.List.Add(item);
    }
    public string Pop()
    {
        var lastElement = this.List.Last();
        this.List.RemoveAt(this.List.Count - 1);
        return lastElement;
    }

    public string Peek()
    {
        return  this.List.Last();
    }
    public bool IsEmpty()
    {
        return this.List.Count == 0;
    }
}