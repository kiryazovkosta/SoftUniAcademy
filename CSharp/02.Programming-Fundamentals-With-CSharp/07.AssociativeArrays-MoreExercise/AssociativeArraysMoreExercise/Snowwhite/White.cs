namespace Snowwhite
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    internal class White
    {
        private static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, int>> dwarfs = new SortedDictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "Once upon a time")
            {
                string[] data = input.Split("<:>", StringSplitOptions.RemoveEmptyEntries);
                string name = data[0].Trim();
                string hat = data[1].Trim();
                int physics = int.Parse(data[2].Trim());

                if (dwarfs.ContainsKey(hat) == false)
                {
                    dwarfs.Add(hat, new Dictionary<string, int>());
                }

                if (dwarfs[hat].ContainsKey(name) == false)
                {
                    dwarfs[hat].Add(name, physics);
                }
                else
                {
                    if (dwarfs[hat][name] < physics )
                    {
                        dwarfs[hat][name] = physics;
                    }
                }
                
                input = Console.ReadLine();
            }

            Dictionary<string, int> sortedDwarfs = new Dictionary<string, int>();
            foreach (var hatColor in dwarfs.OrderByDescending(y => y.Value.Values.Max()).ThenByDescending(x => x.Value.Count()))
            {
                foreach (var dwarf in hatColor.Value)
                {
                    sortedDwarfs.Add($"({hatColor.Key}) {dwarf.Key} <-> ", dwarf.Value);
                }
            }

            foreach (var dwarf in sortedDwarfs.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{dwarf.Key}{dwarf.Value}");
            }
        }
    }
}