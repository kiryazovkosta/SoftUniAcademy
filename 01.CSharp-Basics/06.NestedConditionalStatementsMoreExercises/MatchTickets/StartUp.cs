using System;

namespace MatchTickets
{
    class StartUp
    {
        static void Main(string[] args)
        {
            double bouget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int fansNumber = int.Parse(Console.ReadLine());

            double tripPrice = bouget;
            if (fansNumber <= 4)
            {
                tripPrice = bouget * 0.75;
            }
            else if (fansNumber <= 9)
            {
                tripPrice = bouget * 0.6;
            }
            else if (fansNumber <= 24)
            {
                tripPrice = bouget * 0.5;
            }
            else if (fansNumber <= 49)
            {
                tripPrice = bouget * 0.4;
            }
            else
            {
                tripPrice = bouget * 0.25;

            }

            double sumForTickets = bouget - tripPrice;
            double ticketsPrice = 499.99 * fansNumber;
            if (category == "Normal")
            {
                ticketsPrice = 249.99 * fansNumber;
            }

            if (sumForTickets >= ticketsPrice)
            {
                Console.WriteLine($"Yes! You have {sumForTickets-ticketsPrice:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {ticketsPrice-sumForTickets:F2} leva.");
            }
        }
    }
}
