namespace SumSeconds
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            int firstTime = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int secondTime = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int thirdTime = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            int totalSeconds = firstTime + secondTime + thirdTime;
            int minutes = totalSeconds / 60;
            int seconds = totalSeconds % 60;
            if (seconds > 9)
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }
        }
    }
}