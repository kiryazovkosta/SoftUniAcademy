namespace AMinerTask
{
    #region Using

    using System;
    using System.Collections.Generic;

    #endregion

    internal class Miner
    {
        private static void Main(string[] args)
        {
            Dictionary<string, long> resources = new Dictionary<string, long>();
            string input = Console.ReadLine();
            while (input != "stop")
            {
                string resource = input ?? string.Empty;
                long quantity = long.Parse(Console.ReadLine());

                if (resources.ContainsKey(resource) == false)
                {
                    resources.Add(resource, 0);
                }

                resources[resource] += quantity;

                input = Console.ReadLine();
            }

            foreach (var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}