using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Srabsko_Unleashed
{
    public class Program    
    {
        public static void Main()
        {
            var input = new Dictionary<string, Dictionary<string, long>>();
            while (true)
            {
                var data = Console.ReadLine().Trim();
                if (data.ToLower() == "end")
                {
                    break;
                }
                var indexOfSeparation = data.IndexOf(" @");
                if (indexOfSeparation < 1)
                {
                    continue;
                }

                var TicketPrice = GetTicketPrice(data);
                if (TicketPrice < 0 || data[TicketPrice - 1] != ' ')
                {
                    continue;
                }

                var TicketsAmount = data.LastIndexOf(' ');
                if (TicketsAmount < TicketPrice + 1)
                {
                    continue;
                }
                var singer = data.Substring(0, indexOfSeparation);
                var city = data.Substring(indexOfSeparation + 2, TicketPrice - (indexOfSeparation + 2) - 1);
                var ticketPrise = long.Parse(data.Substring(TicketPrice, TicketsAmount - TicketPrice).Trim());
                var ticketsAmount = long.Parse(data.Substring(TicketsAmount + 1));

                if (!input.ContainsKey(city))
                {
                    input[city] = new Dictionary<string, long>();
                }

                if (!input[city].ContainsKey(singer))
                {
                    input[city][singer] = 0;
                }

                input[city][singer] += ticketPrise * ticketsAmount;
            }
            foreach (var city in input)
            {
                Console.WriteLine(city.Key);
                foreach (var singer in city.Value.OrderByDescending(kvp => kvp.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }

        private static int GetTicketPrice(string performanceData)
        {
            for (int i = performanceData.Length - 1; i >= 6; i--)
            {
                if (char.IsLetter(performanceData[i]))
                {
                    return i + 2;
                }
            }

            return -1;
        }
    }
}