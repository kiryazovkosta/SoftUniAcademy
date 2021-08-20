namespace Clock
{
    using System;
    public class StartUp
    {
        public static void Main()
        {
            int maxHours = 23;
            int maxMinutes = 59;
            for (int hour = 0; hour <= maxHours; hour++)
            {
                for (int minutes = 0; minutes <= maxMinutes; minutes++)
                {
                    Console.WriteLine($"{hour} : {minutes}");
                }
            }
        }
    }
}
