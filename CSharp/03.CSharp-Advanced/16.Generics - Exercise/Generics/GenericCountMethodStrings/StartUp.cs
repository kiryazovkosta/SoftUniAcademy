namespace GenericCountMethodStrings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var boxes = new List<Box<string>>();
            for (int i = 0; i < number; i++)
            {
                boxes.Add(new Box<string>(Console.ReadLine()));
            }

            string box = Console.ReadLine();
            int count = CountBigger<string>(boxes, box);
            Console.WriteLine(count);
        }

        public static int CountBigger<T>(List<Box<T>> boxes, T element)
             where T : IComparable
        {
            return boxes.Where(b => b.Value.CompareTo(element) > 0).Count();
        }
    }
}
