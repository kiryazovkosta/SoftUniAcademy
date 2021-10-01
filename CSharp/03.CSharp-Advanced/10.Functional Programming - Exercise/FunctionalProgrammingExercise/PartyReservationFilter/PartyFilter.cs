using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyReservationFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split(" ").ToList();
            var filters = new List<Filter>();

            string input = Console.ReadLine();
            while (input != "Print")
            {
                string[] data = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];
                string filter = data[1];
                string value = data[2];

                if (command.Contains("Add"))
                {
                    filters.Add(new Filter() { Type = filter, Value = value});
                }
                else if (command.Contains("Remove"))
                {
                    Filter fr = filters.First(f => f.Type == filter && f.Value == value);
                    filters.Remove(fr);
                }

                input = Console.ReadLine();
            }

            foreach (var filter in filters)
            {
                if (filter.Type == "Starts with")
                {
                    names.RemoveAll(n => n.StartsWith(filter.Value));
                }
                else if (filter.Type == "Ends with")
                {
                    names.RemoveAll(n => n.EndsWith(filter.Value));
                }
                else if (filter.Type == "Length")
                {
                    names.RemoveAll(n => n.Length == int.Parse(filter.Value));
                }
                else if (filter.Type == "Contains")
                {
                    names.RemoveAll(n => n.Contains(filter.Value));
                }
            }

            Console.WriteLine(string.Join(" ", names));
        }
    }

    public class Filter
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
