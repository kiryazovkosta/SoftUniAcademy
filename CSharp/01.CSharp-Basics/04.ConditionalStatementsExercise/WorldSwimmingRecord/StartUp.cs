using System;

namespace WorldSwimmingRecord
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double recordTime = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double distance = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double secondsPerMeter = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            double currentTime = distance * secondsPerMeter;
            double extraTime = Math.Floor(distance / 15) * 12.5;
            currentTime += extraTime;

            if (currentTime < recordTime)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {currentTime:F2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {currentTime-recordTime:F2} seconds slower.");
            }
        }
    }
}
