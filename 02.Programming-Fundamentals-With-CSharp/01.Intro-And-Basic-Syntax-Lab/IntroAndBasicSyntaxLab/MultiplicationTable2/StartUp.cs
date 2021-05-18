namespace MultiplicationTable2
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(number)));
            int begin = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(begin)));
            if (begin > 10)
            {
                Console.WriteLine($"{number} X {begin} = {number * begin}");
            }
            else
            {
                for (int i = begin; i <= 10; i++)
                {
                    Console.WriteLine($"{number} X {i} = {number * i}");
                }
            }
        }
    }
}
