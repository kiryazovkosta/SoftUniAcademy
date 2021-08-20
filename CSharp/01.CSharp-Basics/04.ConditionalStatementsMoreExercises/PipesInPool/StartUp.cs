namespace PipesInPool
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            int volume = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int p1 = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int p2 = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double time = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            double p1Volume = p1 * time;
            double p2Volume = p2 * time;

            double pVolume = p1Volume + p2Volume;
            if (pVolume > volume)
            {
                Console.WriteLine($"For {time} hours the pool overflows with {pVolume-volume} liters.");
            }
            else
            {
                double fillAll = (pVolume / volume) * 100;
                double fillP1 = (p1Volume / pVolume) * 100;
                double fillP2 = (p2Volume / pVolume) * 100;
                Console.WriteLine($"The pool is {fillAll:F2}% full. Pipe 1: {fillP1:F2}%. Pipe 2: {fillP2:F2}%.");
            }
        }
    }
}