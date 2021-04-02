namespace ReportSystem
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int counter = 0;
            double csTotal = 0;
            int csCounter = 0;
            double ccTotal = 0;
            int ccCounter = 0;
            int total = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            while (input != "End")
            {
                int price = int.Parse(input);
                if (counter % 2 == 0)
                {
                    if (price <= 100)
                    {
                        total -= price;
                        csTotal += price;
                        csCounter++;
                        Console.WriteLine("Product sold!");
                    }
                    else
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                }
                else
                {
                    if (price >= 10)
                    {
                        total -= price;
                        ccTotal += price;
                        ccCounter++;
                        Console.WriteLine("Product sold!");
                    }
                    else
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                }

                if (total <= 0)
                {
                    break;
                }

                input = Console.ReadLine();
                counter++;
            }

            if (total <= 0)
            {
                Console.WriteLine($"Average CS: {csTotal/csCounter:F2}");
                Console.WriteLine($"Average CC: {ccTotal/ccCounter:F2}");

            }
            else
            {
                Console.WriteLine("Failed to collect required money for charity.");
            }
        }
    }
}
