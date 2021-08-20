namespace BackToThePast
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            double yearSum = 12000;
            double inheritance = double.Parse(Console.ReadLine());
            int year = int.Parse(Console.ReadLine());
            int age = 18;
            for (int i = 1800; i <= year; i++)
            {
                if (i % 2 == 0)
                {
                    inheritance -= yearSum;
                }
                else
                {
                    inheritance -= yearSum + (50 * age);
                }

                age++;
            }

            if (inheritance >= 0)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {inheritance:F2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {Math.Abs(inheritance):F2} dollars to survive.");
            }

        }
    }
}
