namespace HotPotato
{
    using System;
    using System.Collections.Generic;

    public class Potato
    {
        public static void Main(string[] args)
        {
            Queue<string> childrens = new Queue<string>();
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var name in names)
            {
                childrens.Enqueue(name);
            }

            int toss = int.Parse(Console.ReadLine());
            while (childrens.Count > 1)
            {
                for (int i = 0; i < toss - 1; i++)
                {
                    string child = childrens.Dequeue();
                    childrens.Enqueue(child);
                }

                string removed = childrens.Dequeue();
                Console.WriteLine($"Removed {removed}");
            }

            string last = childrens.Dequeue();
            Console.WriteLine($"Last is {last}");
        }
    }
}