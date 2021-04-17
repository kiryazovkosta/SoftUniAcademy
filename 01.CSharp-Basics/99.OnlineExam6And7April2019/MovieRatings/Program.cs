using System;

namespace MovieRatings
{
    class Program
    {
        static void Main(string[] args)
        {
            double minRating = double.MaxValue;
            string minName = string.Empty;
            double maxRating = double.MinValue;
            string maxName = string.Empty;
            double totalRatings = 0.0;

            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                string name = Console.ReadLine();
                double rating = double.Parse(Console.ReadLine());

                if (rating < minRating)
                {
                    minRating = rating;
                    minName = name;
                }

                if (rating > maxRating)
                {
                    maxRating = rating;
                    maxName = name;
                }

                totalRatings += rating;
            }

            Console.WriteLine($"{maxName} is with highest rating: {maxRating:F1}");
            Console.WriteLine($"{minName} is with lowest rating: {minRating:F1}");
            Console.WriteLine($"Average rating: {totalRatings/number:F1}");
        }
    }
}
