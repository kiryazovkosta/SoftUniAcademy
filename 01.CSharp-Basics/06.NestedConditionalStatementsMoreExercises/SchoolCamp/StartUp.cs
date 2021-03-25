namespace SchoolCamp
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string season = Console.ReadLine();
            string group = Console.ReadLine();
            int students = int.Parse(Console.ReadLine());
            int night = int.Parse(Console.ReadLine());

            double price = 0;
            string sport = string.Empty;
            double discount = 0;

            if (group == "boys")
            {
                if (season == "Winter")
                {
                    price = 9.6;
                    sport = "Judo";
                }
                else if (season == "Spring")
                {
                    price = 7.2;
                    sport = "Tennis";
                }
                else if (season == "Summer")
                {
                    price = 15;
                    sport = "Football";
                }
            }
            else if (group == "girls")
            {
                if (season == "Winter")
                {
                    price = 9.6;
                    sport = "Gymnastics";
                }
                else if (season == "Spring")
                {
                    price = 7.2;
                    sport = "Athletics";
                }
                else if (season == "Summer")
                {
                    price = 15;
                    sport = "Volleyball";
                }
            }
            else if (group == "mixed")
            {
                if (season == "Winter")
                {
                    price = 10;
                    sport = "Ski";
                }
                else if (season == "Spring")
                {
                    price = 9.5;
                    sport = "Cycling";
                }
                else if (season == "Summer")
                {
                    price = 20;
                    sport = "Swimming";
                }
            }

            if (students >= 50)
            {
                discount = 0.5;
            }
            else if (students >= 20 && students < 50)
            {
                discount = 0.15;
            }
            else if (students >= 10 && students < 20)
            {
                discount = 0.05;
            }

            double total = (students * price) * night;
            if (discount > 0)
            {
                total = total - (total * discount);
            }

            Console.WriteLine($"{sport} {total:F2} lv.");
        }
    }
}
