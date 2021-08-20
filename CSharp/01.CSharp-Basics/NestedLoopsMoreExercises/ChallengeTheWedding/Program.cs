using System;

namespace ChallengeTheWedding
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            int f = int.Parse(Console.ReadLine());
            int t = int.Parse(Console.ReadLine());
            bool c = false;

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= f; j++)
                {
                    if (t > 0)
                    {
                        Console.Write($"({i} <-> {j}) ");
                    }

                    t--;
                    if (t <= 0)
                    {
                        break;
                        c = true;
                    }
                }

                if (c)
                {
                    break;
                }
            }
        }
    }
}
