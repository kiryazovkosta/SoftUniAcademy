namespace DepositCalculator
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            int amount = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int period = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double rate = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            double accruedInterest = (amount * rate) / 100.0;
            double monthInterest = accruedInterest / 12;

            double sum = amount + (period * monthInterest);
            Console.WriteLine(sum);
        }
    }
}
