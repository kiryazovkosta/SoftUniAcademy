using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));

            List<int> sets = new List<int>();
            int maxPriceSet = int.MinValue;

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int hat = hats.Peek();
                int scarf = scarfs.Peek();
                if (hat > scarf)
                {
                    int sum = hat + scarf;
                    sets.Add(sum);
                    hats.Pop();
                    scarfs.Dequeue();
                    if (sum > maxPriceSet)
                    {
                        maxPriceSet = sum;
                    }
                }
                else if (hat < scarf)
                {
                    hats.Pop();
                }
                else
                {
                    scarfs.Dequeue();
                    hats.Pop();
                    hat++;
                    hats.Push(hat);
                }
            }

            Console.WriteLine($"The most expensive set is: {maxPriceSet}");
            Console.WriteLine(string.Join(" ", sets));
        }
    }
}
