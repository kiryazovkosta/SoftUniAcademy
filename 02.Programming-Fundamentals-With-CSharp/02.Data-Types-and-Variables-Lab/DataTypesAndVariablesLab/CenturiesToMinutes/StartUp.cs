namespace CenturiesToMinutes
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int centuries = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(centuries)));
            int years = centuries * 100;
            long days = (long)(years * 365.2422);
            decimal hours = days * 24;
            decimal minutes = hours * 60;

            Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes");
        }
    }
}
