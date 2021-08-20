namespace Logistics
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int loads = int.Parse(Console.ReadLine());

            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            double sum = 0;
            for (int i = 0; i < loads; i++)
            {
                int load = int.Parse(Console.ReadLine());
                sum += load;
                if (load <= 3)
                {
                    p1 += load;
                }
                else if (load >= 4 && load <= 11)
                {
                    p2 += load;
                }
                else
                {
                    p3 += load;
                }
            }

            double percentageSum = ((p1 * 200.0) + (p2 * 175.0) + (p3 * 120.0)) / sum;
            double p1p = (p1 / sum) * 100;
            double p2p = (p2 / sum) * 100;
            double p3p = (p3 / sum) * 100;
            Console.WriteLine($"{percentageSum:F2}");
            Console.WriteLine($"{p1p:F2}%");
            Console.WriteLine($"{p2p:F2}%");
            Console.WriteLine($"{p3p:F2}%");
        }
    }
}
