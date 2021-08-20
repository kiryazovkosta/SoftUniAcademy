namespace Travelling
{
    using System;
    public class Travelling
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string destination = input;
                double totalPrice = double.Parse(Console.ReadLine());
                input = Console.ReadLine();
                while (input != "End")
                {
                    double price = double.Parse(input);
                    totalPrice -= price;
                    if (totalPrice <= 0)
                    {
                        Console.WriteLine($"Going to {destination}!");
                        break;
                    }

                    input = Console.ReadLine();
                }

                input = Console.ReadLine();
            }
        }
    }
}
