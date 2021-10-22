namespace Froggy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            var lake = new Lake<int>(numbers);
            var reverse = new List<int>();
            foreach (var stone in lake)
            {
                reverse.Add(stone);
            }

            Console.WriteLine(string.Join(", ", reverse));
        }
    }
}
