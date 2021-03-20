namespace WorkingHours
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();
            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                case "Saturday":
                    if (hours >= 10 && hours <= 18)
                    {
                        Console.WriteLine("open");
                    }
                    else
                    {
                        Console.WriteLine("closed");
                    }
                    break;

                default:
                    Console.WriteLine("closed");
                    break;
            }
        }
    }
}
