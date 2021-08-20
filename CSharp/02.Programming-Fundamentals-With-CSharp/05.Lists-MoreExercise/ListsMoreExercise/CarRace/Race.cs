using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRace
{
    public class Race
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();
            int middleIndex = numbers.Count / 2;

            double leftSum = 0;
            for (int i = 0; i < middleIndex; i++)
            {
                int current = numbers[i];
                if (current == 0)
                {
                    leftSum *= 0.8;
                }
                else
                {
                    leftSum += current;
                }
            }

            double rightSum = 0;
            for (int i = numbers.Count - 1; i > middleIndex; i--)
            {
                int current = numbers[i];
                if (current == 0)
                {
                    rightSum *= 0.8;
                }
                else
                {
                    rightSum += current;
                }
            }

            if (leftSum < rightSum)
            {
                Console.WriteLine($"The winner is left with total time: {leftSum}");
            }
            else
            {
                Console.WriteLine($"The winner is right with total time: {rightSum}");
            }
        }
    }
}
