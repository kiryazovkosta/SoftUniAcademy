namespace Combinations
{
    using System;
    public class Combinations
    {
        public static void Main(string[] args)
        {
            int counter = 0;
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i <= number; i++)
            {
                for (int j = 0; j <= number; j++)
                {
                    for (int k = 0; k <= number; k++)
                    {
                        if (i + j + k == number)
                        {
                            counter++;
                        }
                    }
                }
            }

            Console.WriteLine(counter);
        }
    }
}
