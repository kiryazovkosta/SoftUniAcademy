namespace BackIn30Minutes
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(hours)));
            int minutes = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(minutes)));

            minutes += 30;
            if (minutes >= 60)
            {
                hours++;
                minutes -= 60;
            }

            if (hours > 23)
            {
                hours = 0;
            }

            Console.WriteLine($"{hours}:{minutes:D2}");
        }
    }
}
