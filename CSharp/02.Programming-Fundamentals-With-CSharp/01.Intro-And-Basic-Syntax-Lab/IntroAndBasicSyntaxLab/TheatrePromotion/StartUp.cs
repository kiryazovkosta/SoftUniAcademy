namespace TheatrePromotion
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string day = Console.ReadLine();
            int age = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(age)));
            if (age  >= 0 && age <= 18)
            {
                if (day == "Weekday")
                {
                    Console.WriteLine("12$");
                }
                else if (day == "Weekend")
                {
                    Console.WriteLine("15$");
                }
                else
                {
                    Console.WriteLine("5$");
                }
            }
            else if (age > 18 && age <= 64)
            {
                if (day == "Weekday")
                {
                    Console.WriteLine("18$");
                }
                else if (day == "Weekend")
                {
                    Console.WriteLine("20$");
                }
                else
                {
                    Console.WriteLine("12$");
                }
            }
            else if (age > 64 && age <= 122)
            {
                if (day == "Weekday")
                {
                    Console.WriteLine("12$");
                }
                else if (day == "Weekend")
                {
                    Console.WriteLine("15$");
                }
                else
                {
                    Console.WriteLine("10$");
                }
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
