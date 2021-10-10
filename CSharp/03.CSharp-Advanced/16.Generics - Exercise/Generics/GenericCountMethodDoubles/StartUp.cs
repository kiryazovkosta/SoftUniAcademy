namespace GenericCountMethodDoubles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var boxes = new List<Box<double>>();
            for (int i = 0; i < number; i++)
            {
                boxes.Add(new Box<double>(double.Parse(Console.ReadLine())));
            }

            double box = double.Parse(Console.ReadLine());
            int count = CountBigger<double>(boxes, box);
            Console.WriteLine(count);
        }

        public static int CountBigger<T>(List<Box<T>> boxes, T element)
             where T : IComparable
        {
            return boxes.Where(b => b.Value.CompareTo(element) > 0).Count();
        }
    }
}
