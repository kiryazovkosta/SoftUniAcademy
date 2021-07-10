namespace Fight
{
    using System;

    public class Experience
    {
        static void Main(string[] args)
        {
            double wanted = double.Parse(Console.ReadLine());
            int count = int.Parse(Console.ReadLine());
            double current = 0;
            int battleCounter = 0;
            for (battleCounter = 1; battleCounter <= count; battleCounter++)
            {
                double battle = double.Parse(Console.ReadLine());
                if (battleCounter % 15 == 0 )
                {
                    battle += (battle * 0.05);
                }
                else if (battleCounter % 3 == 0)
                {
                    battle += (battle * 0.15);
                }
                else if (battleCounter % 5 == 0)
                {
                    battle -= (battle * 0.10);
                }

                current += battle;

                if (current >= wanted )
                {
                    break;
                }
            }

            if (current >= wanted)
            {
                Console.WriteLine($"Player successfully collected his needed experience for {battleCounter} battles.");
            }
            else
            {
                Console.WriteLine($"Player was not able to collect the needed experience, {wanted-current:F2} more needed.");
            }
        }
    }
}
