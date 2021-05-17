namespace Task06
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int a = 1; a <= 9; a++)
            {
                for (int b = 9; b >= a; b--)
                {
                    for (int c = 0; c <= 9; c++)
                    {
                        for (int d = 9; d >= c; d--)
                        {
                            int sum = a + b + c + d;
                            int pro = a * b * c * d;

                            if (sum == pro && number % 10 == 5)
                            {
                                Console.WriteLine($"{a}{b}{c}{d}");
                                return;
                            }

                            if (pro / sum == 3 && number % 3 == 0)
                            {
                                Console.WriteLine($"{d}{c}{b}{a}");
                                return;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Nothing found");
        }
    }
}
