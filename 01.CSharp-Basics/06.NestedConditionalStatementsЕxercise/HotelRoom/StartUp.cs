namespace HotelRoom
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());

            double studioPrice = 50.0;
            double apartamentPrice = 65.0;

            switch (month)
            {
                case "May":
                case "October":
                    if (nights > 14)
                    {
                        studioPrice -= studioPrice * 0.3;
                        apartamentPrice -= apartamentPrice * 0.1;
                    }
                    else if (nights > 7)
                    {
                        studioPrice -= studioPrice * 0.05;   
                    }

                    break;

                case "June":
                case "September":
                    studioPrice = 75.2;
                    apartamentPrice = 68.7;
                    if (nights > 14)
                    {
                        studioPrice -= studioPrice * 0.2;
                        apartamentPrice -= apartamentPrice * 0.1;
                    }
                    break;

                case "July":
                case "August":
                    studioPrice = 76;
                    apartamentPrice = 77;
                    if (nights > 14)
                    {
                        apartamentPrice -= apartamentPrice * 0.1;
                    }
                    break;

                default:
                    break;
            }

            Console.WriteLine($"Apartment: {nights * apartamentPrice:F2} lv.");
            Console.WriteLine($"Studio: {nights * studioPrice:F2} lv.");
        }
    }
}
