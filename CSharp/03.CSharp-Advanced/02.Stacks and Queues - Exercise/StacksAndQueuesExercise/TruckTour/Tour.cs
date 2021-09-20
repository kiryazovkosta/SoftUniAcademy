namespace TruckTour
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tour
    {
        private static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Queue<int[]> pumps = new Queue<int[]>();
            for (int i = 0; i < count; i++)
            {
                int[] data = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                pumps.Enqueue(data);
            }

            int index = 0;
            while (true)
            {
                int[] pumpData = pumps.Dequeue();
                capacity += pumpData[0];
                if (capacity < pumpData[1])
                {
                    capacity = 0;
                    index++;
                    pumps.Enqueue(pumpData);
                }

                if (pumps.Count == 0)
                {
                    break;
                }
            }

            Console.WriteLine(index);
        }
    }
}