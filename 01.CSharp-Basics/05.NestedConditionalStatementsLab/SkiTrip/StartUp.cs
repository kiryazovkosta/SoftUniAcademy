namespace SkiTrip
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string rating = Console.ReadLine();

            double roomPrice = -1.0;
            if (room == "room for one person")
            {
                roomPrice = (days - 1) * 18;
            }
            else if (room == "apartment")
            {
                roomPrice = (days - 1) * 25;
                if (days < 10)
                {
                    roomPrice = roomPrice - (roomPrice * 0.3);
                }
                else if (days >= 10 && days <= 15)
                {
                    roomPrice = roomPrice - (roomPrice * 0.35);
                }
                else
                {
                    roomPrice = roomPrice - (roomPrice * 0.5);
                }
            }
            else
            {
                roomPrice = (days - 1) * 35;
                if (days < 10)
                {
                    roomPrice = roomPrice - (roomPrice * 0.1);
                }
                else if (days >= 10 && days <= 15)
                {
                    roomPrice = roomPrice - (roomPrice * 0.15);
                }
                else
                {
                    roomPrice = roomPrice - (roomPrice * 0.2);
                }
            }

            if (rating == "positive")
            {
                roomPrice = roomPrice + (roomPrice * 0.25);
            }
            else
            {
                roomPrice = roomPrice - (roomPrice * 0.1);
            }

            Console.WriteLine($"{roomPrice:F2}");
        }
    }
}
