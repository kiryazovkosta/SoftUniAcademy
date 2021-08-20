namespace Vacation
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(count)));
            string type = Console.ReadLine();
            string day = Console.ReadLine();

            double price = 0.0;
            double discount = 0.0;

            switch (type)
            {
                case "Students":
                    if (count >= 30)
                    {
                        discount = 0.15;
                    }

                    switch (day)
                    {
                        case "Friday":
                            price = 8.45;
                            break;

                        case "Saturday":
                            price = 9.80;
                            break;

                        case "Sunday":
                            price = 10.46;
                            break;

                        default:
                            break;
                    }

                    break;

                case "Business":
                    if (count >= 100)
                    {
                        count -= 10;
                    }

                    switch (day)
                    {
                        case "Friday":
                            price = 10.90;
                            break;

                        case "Saturday":
                            price = 15.60;
                            break;

                        case "Sunday":
                            price = 16;
                            break;

                        default:
                            break;
                    }
                    break;

                case "Regular":
                    if (count >= 10 && count <= 20)
                    {
                        discount = 0.05;
                    }

                    switch (day)
                    {
                        case "Friday":
                            price = 15;
                            break;

                        case "Saturday":
                            price = 20;
                            break;

                        case "Sunday":
                            price = 22.50;
                            break;

                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }

            double total = count * price;
            if (discount > 0)
            {
                total = total - (total * discount);
            }

            Console.WriteLine($"Total price: {total:F2}");
        }
    }
}
