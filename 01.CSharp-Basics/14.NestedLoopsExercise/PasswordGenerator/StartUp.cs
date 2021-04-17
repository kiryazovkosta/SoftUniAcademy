namespace PasswordGenerator
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            for (int i = 1; i < n; i++)
            {
                for (int j = 1; j < n; j++)
                {
                    for (int k = 96 +1; k <= 96 + l; k++)
                    {
                        for (int m = 96 + 1; m <= 96 + l; m++)
                        {
                            for (int o = 1; o <= n; o++)
                            {
                                if (o > i && o > j)
                                {
                                    Console.Write($"{i}{j}{(char)k}{(char)m}{o} ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
