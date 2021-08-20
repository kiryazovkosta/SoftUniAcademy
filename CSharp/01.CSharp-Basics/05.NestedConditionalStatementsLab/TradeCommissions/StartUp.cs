namespace TradeCommissions
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
            if (sales >= 0)
            {
                if (city == "Sofia")
                {
                    if (sales >= 0 && sales <= 500)
                    {
                        Console.WriteLine($"{sales*0.05:F2}");
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        Console.WriteLine($"{sales * 0.07:F2}");
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        Console.WriteLine($"{sales * 0.08:F2}");
                    }
                    else
                    {
                        Console.WriteLine($"{sales * 0.12:F2}");
                    }
                }
                else if (city == "Varna")
                {
                    if (sales >= 0 && sales <= 500)
                    {
                        Console.WriteLine($"{sales * 0.045:F2}");
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        Console.WriteLine($"{sales * 0.075:F2}");
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        Console.WriteLine($"{sales * 0.1:F2}");
                    }
                    else
                    {
                        Console.WriteLine($"{sales * 0.13:F2}");
                    }
                }
                else if (city == "Plovdiv")
                {
                    if (sales >= 0 && sales <= 500)
                    {
                        Console.WriteLine($"{sales * 0.055:F2}");
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        Console.WriteLine($"{sales * 0.08:F2}");
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        Console.WriteLine($"{sales * 0.12:F2}");
                    }
                    else
                    {
                        Console.WriteLine($"{sales * 0.145:F2}");
                    }
                }
                else
                {
                    Console.WriteLine("error");
                }
            }
            else
            {
                Console.WriteLine("error");
            }

        }
    }
}
