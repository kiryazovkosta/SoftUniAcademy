namespace Volleyball
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string year = Console.ReadLine();
            int holidays = int.Parse(Console.ReadLine());
            int homedays = int.Parse(Console.ReadLine());

            int sofiaDays = 48 - homedays;
            double sofiaGames = sofiaDays * 0.75;
            double holidaysGames = holidays * (2.0 / 3.0);
            double totalGames = sofiaGames + homedays + holidaysGames;

            if (year == "leap")
            {
                totalGames += totalGames * 0.15;
            }

            Console.WriteLine(Math.Floor(totalGames));
        }
    }
}
