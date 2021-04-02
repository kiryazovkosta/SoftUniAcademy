using System;

namespace MinNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int min = Int32.MaxValue;
            string input = Console.ReadLine();
            while (input != "Stop")
            {
                int number = int.Parse(input);
                if (number < min)
                {
                    min = number;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(min);
        }
    }
}
