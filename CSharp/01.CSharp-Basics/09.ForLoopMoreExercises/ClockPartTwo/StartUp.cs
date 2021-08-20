namespace ClockPartTwo
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int maxHours = 23;
            int maxMinutes = 59;
            int maxSeconds = 59;
            for (int hour = 0; hour <= maxHours; hour++)
            {
                for (int minutes = 0; minutes <= maxMinutes; minutes++)
                {
                    for (int seconds = 0; seconds <= maxSeconds; seconds++)
                    {
                        Console.WriteLine($"{hour} : {minutes} : {seconds}");
                    }
                }
            }
        }
    }
}
