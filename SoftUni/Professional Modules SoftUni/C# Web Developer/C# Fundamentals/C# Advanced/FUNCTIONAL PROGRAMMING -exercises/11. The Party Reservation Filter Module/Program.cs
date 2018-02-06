using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    public class Filter
    {
        public string Command { get; set; }

        public string Arg { get; set; }

        public static string[] FilterCollection(string[] collection, Func<string, bool> filter)
        {
            return collection.Where(n => !filter(n)).ToArray();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split();
            var filters = GetFilters();
            names = FilterNames(filters, names);
            Console.WriteLine(string.Join(" ", names));
        }

        private static string[] FilterNames(HashSet<Filter> filters, string[] names)
        {
            foreach (Filter filter in filters)
            {
                if (filter.Command.Contains("starts"))
                {
                    names = Filter.FilterCollection(names, n => n.StartsWith(filter.Arg, StringComparison.InvariantCultureIgnoreCase));
                }
                else if (filter.Command.Contains("ends"))
                {
                    names = Filter.FilterCollection(names, n => n.EndsWith(filter.Arg, StringComparison.InvariantCultureIgnoreCase));
                }
                else if (filter.Command.Contains("length"))
                {
                    names = Filter.FilterCollection(names, n => n.Length == int.Parse(filter.Arg));
                }
                else if (filter.Command.Contains("contains"))
                {
                    names = Filter.FilterCollection(names, n => n.ToLower().Contains(filter.Arg.ToLower()));
                }
            }

            return names;
        }

        private static HashSet<Filter> GetFilters()
        {
            var filters = new HashSet<Filter>();
            var input = Console.ReadLine()
                .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToArray();

            while (input[0] != "Print")
            {

                var currentFilter = new Filter() { Command = input[1].ToLower(), Arg = input[2] };

                if (input[0].StartsWith("Add"))
                {
                    filters.Add(currentFilter);
                }
                else if (input[0].StartsWith("Remove"))
                {
                    filters.RemoveWhere(f =>
                            f.Arg == currentFilter.Arg &&
                            f.Command == currentFilter.Command);
                }

                input = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            }

            return filters;
        }
    }
}