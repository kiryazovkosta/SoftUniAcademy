namespace Clock
{
    using System;
    public class Clock
    {
        public static void Main(string[] args)
        {
            int startHour = 0;
            int endHour = 23;
            int startMinute = 0;
            int endMinute = 59;
            for (int hour = startHour; hour <= endHour; hour++)
            {
                for (int minute = startMinute; minute <= endMinute; minute++)
                {
                    Console.WriteLine($"{hour}:{minute}");
                }
            }
        }
    }
}
