namespace SkiRental
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class SkiRental
    {
        private List<Ski> data;

        public SkiRental(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Ski>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get { return data.Count; }
        }

        public void Add(Ski ski)
        {
            if (data.Count + 1 <= Capacity)
            {
                data.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            bool success = false;
            Ski skiToRemove = data.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);
            if (skiToRemove != null)
            {
                success = data.Remove(skiToRemove);
            }
            
            return success;
        }

        public Ski GetNewestSki()
        {
            return data.OrderByDescending(s => s.Year).FirstOrDefault();
        }

        public Ski GetSki(string manufacturer, string model)
        {
            return data.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var ski in data)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString();
        }
    }
}
