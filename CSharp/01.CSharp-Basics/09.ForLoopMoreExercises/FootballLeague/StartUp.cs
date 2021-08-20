namespace FootballLeague
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            int stadium = int.Parse(Console.ReadLine());
            int fans = int.Parse(Console.ReadLine());
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            for (int i = 0; i < fans; i++)
            {
                string sector = Console.ReadLine();
                switch (sector)
                {
                    case "A":
                        p1++;
                        break;

                    case "B":
                        p2++;
                        break;
                        
                    case "V":
                        p3++;
                        break;

                    case "G":
                        p4++;
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine($"{(p1 * 1.0) / fans * 100:F2}%");
            Console.WriteLine($"{(p2 * 1.0) / fans * 100:F2}%");
            Console.WriteLine($"{(p3 * 1.0) / fans * 100:F2}%");
            Console.WriteLine($"{(p4 * 1.0) / fans * 100:F2}%");
            Console.WriteLine($"{(fans * 1.0) / stadium * 100:F2}%");
        }
    }
}
