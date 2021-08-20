namespace Histogram
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            int p5 = 0;

            for (int i = 0; i < size; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number < 200)
                {
                    p1++;
                }
                else if (number >= 200 && number <= 399)
                {
                    p2++;
                }
                else if (number >= 400 && number <= 599)
                {
                    p3++;
                }
                else if (number >= 600 && number <= 799)
                {
                    p4++;
                }
                else if (number >= 800)
                {
                    p5++;
                }
            }

            double p1p = ((p1 * 1.0) / size) * 100.00;
            double p2p = ((p2 * 1.0) / size) * 100.00;
            double p3p = ((p3 * 1.0) / size) * 100.00;
            double p4p = ((p4 * 1.0) / size) * 100.00;
            double p5p = ((p5 * 1.0) / size) * 100.00;

            Console.WriteLine($"{p1p:F2}%");
            Console.WriteLine($"{p2p:F2}%");
            Console.WriteLine($"{p3p:F2}%");
            Console.WriteLine($"{p4p:F2}%");
            Console.WriteLine($"{p5p:F2}%");
        }
    }
}
