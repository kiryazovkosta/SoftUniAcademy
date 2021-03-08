using System;

namespace FishTank
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int width = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int height = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double percentage = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            double volume = (length * width * height) * 0.001;
            double perc = percentage * 0.01;

            double realVolume = volume * (1 - perc);
            Console.WriteLine(realVolume);
        }
    }
}
