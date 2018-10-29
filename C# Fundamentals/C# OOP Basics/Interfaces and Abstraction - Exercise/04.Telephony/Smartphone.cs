using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Smartphone : ISmart, IPhone
{
    //public string Browsing { get; set; }
    //public string Call { get; set; }
    public string Model { get; private set; }

    public Smartphone(string model)
    {
        this.Model = model;
    }
    public string Browse(string url)
    {
        if (this.IsValidUrl(url))
        {
            return $"Browsing: {url}!";
        }

        return "Invalid URL!";
    }

    public string Call (string phoneNumber)
    {
        if (this.IsValidNumber(phoneNumber))
        {
            return $"Calling... {phoneNumber}";
        }

        return "Invalid number!";
    }

    public bool IsValidNumber(string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            if (!char.IsDigit(str[i]))
            {
               
                return false;
            }
        }
        return true;
    }


    public bool IsValidUrl(string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            if (char.IsDigit(str[i]))
            {
              
                return false;
            }
        }
        return true;
    }
}

