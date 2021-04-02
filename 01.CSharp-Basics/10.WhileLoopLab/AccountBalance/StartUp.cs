namespace AccountBalance
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double sum = 0; 
            while (input != "NoMoreMoney")
            {
                double money = double.Parse(input);
                if (money < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                sum += money;
                Console.WriteLine($"Increase: {money:F2}");
                input = Console.ReadLine();
            }

            Console.WriteLine($"Total: {sum:F2}");
        }
    }
}
