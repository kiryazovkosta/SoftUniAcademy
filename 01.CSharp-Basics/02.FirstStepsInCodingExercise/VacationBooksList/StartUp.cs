namespace VacationBooksList
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            int totalPages = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double pagesPerHour = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int readingDays = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            double totalReadingTime = totalPages / pagesPerHour;
            double hoursReadingPerDay = totalReadingTime / readingDays;

            Console.WriteLine(hoursReadingPerDay);
        }
    }
}
