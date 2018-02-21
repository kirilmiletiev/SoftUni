using System;
using System.Collections.Generic;
using System.Text;


class PriceCalculator
{
    public decimal PricePerDay { get; set; }
    public int Days { get; set; }
    public string Season { get; set; }
    public string DiscountType { get; set; }

    public PriceCalculator(decimal pricePerDay, int days, string season)
    {
        this.PricePerDay = pricePerDay;
        this.Season = season;
        this.Days = days;
        decimal sum = Calc(pricePerDay, days, season);
        Console.WriteLine($"{sum:f2}");
    }
    

    public PriceCalculator(decimal pricePerDay, int days, string season, string discount)
    {
        this.PricePerDay = pricePerDay;
        this.Season = season;
        this.Days = days;
        this.DiscountType = discount;

        var sum = Calc(pricePerDay, days, season);
        if (discount == "VIP")
        {
            sum = sum - ((sum / 100) * 20);
        }
        else if(discount == "SecondVisit")
        {
            sum = sum - ((sum / 100) * 10);
        }
        Console.WriteLine($"{sum:f2}");
    }


    private decimal Calc(decimal pricePerDay, int days, string season)
    {

        var result = pricePerDay * days;
        if (season == "Spring")
        {
            result = result * 2;
        }
        else if (season == "Winter")
        {
            result = result * 3;
        }
        else if (season == "Summer")
        {
            result = result * 4;
        }
        return result;
    }

}