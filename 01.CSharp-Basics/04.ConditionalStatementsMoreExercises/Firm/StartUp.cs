using System;

namespace Firm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int hours = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int days = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int workers = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            double workingHours = (days * 0.9) * 8;
            double overtimeHours = days * workers * 2;

            double totalWorkingHours = Math.Floor(workingHours + overtimeHours);
            if (totalWorkingHours >= hours)
            {
                Console.WriteLine($"Yes!{totalWorkingHours-hours} hours left.");
            }
            else
            {
                Console.WriteLine($"Not enough time!{Math.Abs(totalWorkingHours-hours)} hours needed.");
            }
        }
    }
}
