namespace CupsAndBottles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Cap
    {
        static void Main(string[] args)
        {
            var cups = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());
            var bottles = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            bool isNew = true;
            int cup = 0;
            int wastedWater = 0;
            while (cups.Count > 0 && bottles.Count > 0)
            {
                if (isNew)
                {
                    cup = cups.Peek();
                    isNew = false;
                }

                var bottle = bottles.Pop();

                if (bottle >= cup)
                {
                    wastedWater += (bottle - cup);
                    cups.Dequeue();
                    isNew = true;
                }
                else
                {
                    cup -= bottle;
                }
            }

            Console.WriteLine(cups.Any() ? $"Cups: {string.Join(" ", cups)}" : $"Bottles: {string.Join(" ", bottles)}");

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}