namespace Task03
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string rating = Console.ReadLine();

            double price = 0.0;
            if (type == "room for one person")
            {
                price = 18.00;
            } else if (type == "apartment")
            {
                price = 25.00;
            }
            else if (type == "president apartment")
            {
                price = 35.00;
            }

            if (price > 0)
            {
                double totalPrice = (days - 1) * price;
                if (days < 10)
                {
                    if (type == "apartment")
                    {
                        totalPrice = totalPrice - (totalPrice * 0.3);
                    }
                    else if (type == "president apartment")
                    {
                        totalPrice = totalPrice - (totalPrice * 0.1);
                    }
                }
                else if (days >= 10 && days <= 15)
                {
                    if (type == "apartment")
                    {
                        totalPrice = totalPrice - (totalPrice * 0.35);
                    }
                    else if (type == "president apartment")
                    {
                        totalPrice = totalPrice - (totalPrice * 0.15);
                    }
                }
                else if (days > 15)
                {
                    if (type == "apartment")
                    {
                        totalPrice = totalPrice - (totalPrice * 0.5);
                    }
                    else if (type == "president apartment")
                    {
                        totalPrice = totalPrice - (totalPrice * 0.2);
                    }
                }

                if (rating == "negative")
                {
                    totalPrice = totalPrice - (totalPrice * 0.1);
                }
                else
                {
                    totalPrice = totalPrice + (totalPrice * 0.25);
                }

                Console.WriteLine($"{totalPrice:F2}");
            }


        }
    }
}
