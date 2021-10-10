using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodIntegers
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var boxes = new List<Box<int>>();
            while (count > 0)
            {
                boxes.Add(new Box<int>(int.Parse(Console.ReadLine())));
                count--;
            }

            int[] indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Swap(boxes, indexes[0], indexes[1]);
            foreach (var box in boxes)
            {
                Console.WriteLine(box.ToString());
            }
        }

        public static void Swap<T>(List<Box<T>> boxes, int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >= boxes.Count)
            {
                throw new IndexOutOfRangeException(nameof(firstIndex));
            }

            if (secondIndex < 0 || secondIndex >= boxes.Count)
            {
                throw new IndexOutOfRangeException(nameof(secondIndex));
            }

            Box<T> temp = boxes[firstIndex];
            boxes[firstIndex] = boxes[secondIndex];
            boxes[secondIndex] = temp;
        }
    }
}
