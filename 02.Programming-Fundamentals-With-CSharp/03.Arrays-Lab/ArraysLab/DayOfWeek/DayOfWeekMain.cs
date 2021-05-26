namespace DayOfWeek
{
    using System;
    public class DayOfWeekMain
    {
        static void Main(string[] args)
        {
            string[] days = new string[]
            {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            int dayIndex = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(dayIndex)));
            if (dayIndex >= 1 && dayIndex <= days.Length)
            {
                Console.WriteLine(days[dayIndex-1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
