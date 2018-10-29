using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class RandomList : List<string>
{
   public Random rnd;

    public RandomList()
    {
        this.rnd = new Random();
    }

    public  string RandomString(List<string> data)
    {
        int index = rnd.Next(0, data.Count - 1);
        string str = data[index];
        data.RemoveAt(index);
        return str;
    }
}