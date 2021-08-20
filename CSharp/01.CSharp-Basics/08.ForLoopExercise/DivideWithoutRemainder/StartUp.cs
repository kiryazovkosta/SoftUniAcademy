namespace DivideWithoutRemainder
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;

            int size = int.Parse(Console.ReadLine());
            for (int i = 0; i < size; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number % 2 == 0)
                {
                    p1++;
                }
                if (number % 3 == 0)
                {
                    p2++;
                }
                if (number % 4 == 0)
                {
                    p3++;
                }
            }

            double p1p = ((p1 * 1.0) / size) * 100.00;
            double p2p = ((p2 * 1.0) / size) * 100.00;
            double p3p = ((p3 * 1.0) / size) * 100.00;

            Console.WriteLine($"{p1p:F2}%");
            Console.WriteLine($"{p2p:F2}%");
            Console.WriteLine($"{p3p:F2}%");
        }
    }
}
