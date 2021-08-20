using System;

namespace TransportPrice
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int distance = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            string tripTime = Console.ReadLine();
            if (distance < 20.0)
            {
                if (tripTime == "day")
                {
                    Console.WriteLine($"{distance * 0.79 + 0.70:F2}");
                }
                else
                {
                    Console.WriteLine($"{distance * 0.90 + 0.70:F2}");
                }
            }
            else if (distance >= 20.0 && distance < 100.0)
            {
                Console.WriteLine($"{distance * 0.09:F2}");
            }
            else if (distance >= 100.0)
            {
                Console.WriteLine($"{distance*0.06:F2}");
            }
        }
    }
}
