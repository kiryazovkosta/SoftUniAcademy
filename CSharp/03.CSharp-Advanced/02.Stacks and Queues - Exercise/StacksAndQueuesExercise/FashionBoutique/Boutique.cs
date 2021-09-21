namespace FashionBoutique
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class Boutique
    {
        private static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray());

            int capacity = int.Parse(Console.ReadLine());

            int currentCapacity = 0;
            int boxesCount = 1;

            while (clothes.Count > 0)
            {
                int cloth = clothes.Peek();
                currentCapacity += cloth;

                if (currentCapacity <= capacity)
                {
                    clothes.Pop();
                }
                else if (currentCapacity == capacity)
                {
                    currentCapacity = 0;
                    boxesCount++;
                    clothes.Pop();
                }
                else
                {
                    currentCapacity = 0;
                    boxesCount++;
                }
            }

            Console.WriteLine(boxesCount);
        }
    }
}