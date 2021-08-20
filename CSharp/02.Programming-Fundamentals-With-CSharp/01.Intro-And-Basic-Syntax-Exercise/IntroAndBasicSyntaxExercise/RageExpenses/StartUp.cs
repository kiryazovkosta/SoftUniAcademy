namespace RageExpenses
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());

            int trashedKeyboard = 0;
            double expenses = 0.0;
            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    expenses += headsetPrice;
                }

                if (i % 3 == 0)
                {
                    expenses += mousePrice;
                }

                if (i % 2 == 0 && i % 3 == 0)
                {
                    expenses += keyboardPrice;
                    trashedKeyboard++;
                    if (trashedKeyboard % 2 == 0)
                    {
                        expenses += displayPrice;
                    }
                }
            }

            Console.WriteLine($"Rage expenses: {expenses:F2} lv.");
        }
    }
}
