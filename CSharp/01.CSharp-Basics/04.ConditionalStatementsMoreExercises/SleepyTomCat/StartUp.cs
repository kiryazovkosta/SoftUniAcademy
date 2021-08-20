namespace SleepyTomCat
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            int holidays = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int workingDays = 365 - holidays;

            int playingTime = (holidays * 127) + (workingDays * 63);
            if (playingTime > 30000)
            {
                Console.WriteLine("Tom will run away");
                int diff = playingTime - 30000;
                int hours = diff / 60;
                int minutes = diff % 60;
                Console.WriteLine($"{hours} hours and {minutes} minutes more for play");
            }
            else
            {
                Console.WriteLine("Tom sleeps well");
                int diff = 30000 - playingTime;
                int hours = diff / 60;
                int minutes = diff % 60;
                Console.WriteLine($"{hours} hours and {minutes} minutes less for play");
            }
        }
    }
}