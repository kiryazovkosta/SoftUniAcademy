using System;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 1111; i <= 9999; i++)
            {
                string n = i.ToString();
                int n1 = int.Parse(n[3].ToString());
                int n2 = int.Parse(n[2].ToString());
                int n3 = int.Parse(n[1].ToString());
                int n4 = int.Parse(n[0].ToString());
                if (n1 != 0 && number % n1 == 0)
                {
                    if (n2 != 0 && number % n2 == 0)
                    {
                        if (n3 != 0 && number % n3 == 0)
                        {
                            if (n4 != 0 && number % n4 == 0)
                            {
                                Console.Write($"{n} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
