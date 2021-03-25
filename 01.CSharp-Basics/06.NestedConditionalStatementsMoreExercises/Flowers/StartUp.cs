using System;

namespace Flowers
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int hrizantemi = int.Parse(Console.ReadLine());
            int rozi = int.Parse(Console.ReadLine());
            int laleta = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            char isHoliday = char.Parse(Console.ReadLine());

            double hrezantemaPrice = 0.0;
            double roziPrice = 0.0;
            double lalePrice = 0.0;

            switch (season)
            {
                case "Spring":
                case "Summer":
                    hrezantemaPrice = 2.0;
                    roziPrice = 4.1;
                    lalePrice = 2.5;
                    break;

                case "Autumn":
                case "Winter":
                    hrezantemaPrice = 3.75;
                    roziPrice = 4.5;
                    lalePrice = 4.15;
                    break;

                default:
                    break;
            }

            if (isHoliday == 'Y')
            {
                hrezantemaPrice = hrezantemaPrice + (hrezantemaPrice * 0.15);
                roziPrice = roziPrice + (roziPrice * 0.15);
                lalePrice = lalePrice + (lalePrice * 0.15);
            }

            double flowersPrice = (hrizantemi * hrezantemaPrice)
                + (rozi * roziPrice)
                + (laleta * lalePrice);

            if (season == "Spring" && laleta > 7)
            {
                flowersPrice = flowersPrice - (flowersPrice * 0.05);
            }

            if (season == "Winter" && rozi >= 10)
            {
                flowersPrice = flowersPrice - (flowersPrice * 0.1);
            }

            if (hrizantemi + rozi + laleta > 20)
            {
                flowersPrice = flowersPrice - (flowersPrice * 0.2);
            }

            flowersPrice += 2.0;
            Console.WriteLine($"{flowersPrice:F2}");
        }
    }
}
