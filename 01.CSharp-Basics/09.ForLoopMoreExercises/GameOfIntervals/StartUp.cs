namespace GameOfIntervals
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int moves = int.Parse(Console.ReadLine());
            double score = 0;
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            int p5 = 0;
            int p6 = 0;
            for (int i = 0; i < moves; i++)
            {
                int points = int.Parse(Console.ReadLine());
                if (points >= 0 && points <= 9)
                {
                    score += points * 0.2;
                    p1++;
                }
                else if (points >= 10 && points <= 19)
                {
                    score += points * 0.3;
                    p2++;
                }
                else if (points >= 20 && points <= 29)
                {
                    score += points * 0.4;
                    p3++;
                }
                else if (points >= 30 && points <= 39)
                {
                    score += 50;
                    p4++;
                }
                else if (points >= 40 && points <= 50)
                {
                    score += 100;
                    p5++;
                }
                else
                {
                    if (score != 0)
                    {
                        score /= 2;
                    }

                    p6++;
                }
            }

            Console.WriteLine($"{score:F2}");
            Console.WriteLine($"From 0 to 9: {(p1 * 1.0) / moves * 100:F2}%");
            Console.WriteLine($"From 10 to 19: {(p2 * 1.0) / moves * 100:F2}%");
            Console.WriteLine($"From 20 to 29: {(p3 * 1.0) / moves * 100:F2}%");
            Console.WriteLine($"From 30 to 39: {(p4 * 1.0) / moves * 100:F2}%");
            Console.WriteLine($"From 40 to 50: {(p5 * 1.0) / moves * 100:F2}%");
            Console.WriteLine($"Invalid numbers: {(p6 * 1.0) / moves * 100:F2}%");

        }
    }
}
