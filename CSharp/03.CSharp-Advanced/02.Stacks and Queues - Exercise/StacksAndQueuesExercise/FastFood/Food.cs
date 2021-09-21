namespace FastFood
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Food
    {
        private static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());
            int maxOrder = orders.Max();

            while (orders.Count > 0)
            {
                int order = orders.Peek();

                foodQuantity -= order;
                if (foodQuantity < 0)
                {
                    break;
                }

                orders.Dequeue();
            }

            Console.WriteLine(maxOrder);
            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders.ToArray())}");
            }
        }
    }
}