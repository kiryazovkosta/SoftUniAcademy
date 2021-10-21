using System;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Queue<int> first = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            Stack<int> second = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));

            int claimed = 0;
            while (first.Count > 0 && second.Count > 0)
            {
                int f = first.Peek();
                int s = second.Peek();

                int sum = f + s;
                if (sum % 2 == 0)
                {
                    claimed += sum;
                    first.Dequeue();
                    second.Pop();
                }
                else
                {
                    second.Pop();
                    first.Enqueue(s);
                }
            }

            if (first.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else if (second.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimed >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimed}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimed}");
            }
        }
    }
}