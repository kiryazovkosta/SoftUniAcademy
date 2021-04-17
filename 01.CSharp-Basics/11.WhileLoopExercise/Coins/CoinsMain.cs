namespace Coins
{
    using System;
    public class CoinsMain
    {
        public static void Main(string[] args)
        {
            int money = (int)(double.Parse(Console.ReadLine()) * 100);
            int coins = 0;
            while (money > 0)
            {
                if (money >= 200)
                {
                    coins++;
                    money -= 200;
                }
                else if (money >= 100)
                {
                    coins++;
                    money -= 100;
                }
                else if (money >= 50)
                {
                    coins++;
                    money -= 50;
                }
                else if (money >= 20)
                {
                    coins++;
                    money -= 20;
                }
                else if (money >= 10)
                {
                    coins++;
                    money -= 10;
                }
                else if (money >= 5)
                {
                    coins++;
                    money -= 5;
                }
                else if (money >= 2)
                {
                    coins++;
                    money -= 2;
                }
                else if (money >= 1)
                {
                    coins++;
                    money -= 1;
                }
            }

            Console.WriteLine(coins);
        }
    }
}
