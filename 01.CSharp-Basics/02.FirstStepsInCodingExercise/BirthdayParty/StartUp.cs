namespace BirthdayParty
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            double hallRent = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            double cakePrice = hallRent * 0.2;
            double drinksPrice = cakePrice - (cakePrice * 0.45);
            double animatorPrice = hallRent / 3;

            double totalPrice = hallRent + cakePrice + drinksPrice + animatorPrice;
            Console.WriteLine(totalPrice);
        }
    }
}