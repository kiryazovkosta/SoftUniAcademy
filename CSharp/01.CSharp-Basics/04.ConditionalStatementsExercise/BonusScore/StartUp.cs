namespace BonusScore
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double bonus = 0.0;

            if (number <= 100)
            {
                bonus = 5;
            }
            else if (number > 1000)
            {
                bonus = number * 0.1;
            }
            else
            {
                bonus = number * 0.2;
            }

            if (number % 2 == 0)
            {
                bonus += 1;
            }
            else if (number % 10 == 5)
            {
                bonus += 2;
            }

            Console.WriteLine(bonus);
            Console.WriteLine(number + bonus);
        }
    }
}
