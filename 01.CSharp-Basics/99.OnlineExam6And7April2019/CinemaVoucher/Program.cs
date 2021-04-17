using System;

namespace CinemaVoucher
{
    class Program
    {
        static void Main(string[] args)
        {
            int voucher = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            int products = 0;
            int tickets = 0;
            while (input != "End")
            {
                if (input.Length > 8)
                {
                    int firstSimbol = (int)input[0];
                    int secondSimbol = (int)input[1];
                    int sum = firstSimbol + secondSimbol;
                    if (sum > voucher)
                    {
                        break;
                    }
                    voucher -= sum;
                    tickets++;
                    if (voucher <= 0)
                    {
                        break;
                    }
                }
                else
                {
                    int sum = (int)input[0];
                    if (sum > voucher)
                    {
                        break;
                    }
                    voucher -= sum;
                    products++;
                    if (voucher <= 0)
                    {
                        break;
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(tickets);
            Console.WriteLine(products);
        }
    }
}
