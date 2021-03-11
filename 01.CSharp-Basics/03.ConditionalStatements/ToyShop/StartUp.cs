namespace ToyShop
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            double puzzlePrice = 2.60;
            double talkingDollPrice = 3.00;
            double teddyBearPrice = 4.10;
            double minionPrice = 8.20;
            double truckPrice = 2.00;

            double bigOrderPercentageDiscount = 0.25;
            double rentPercentage = 0.1;

            double tripPrice = double.Parse(Console.ReadLine());
            int puzzlesNumber = int.Parse(Console.ReadLine());
            int talkingDollsNumber = int.Parse(Console.ReadLine());
            int teddyBearsNumber = int.Parse(Console.ReadLine());
            int minionsNumber = int.Parse(Console.ReadLine());
            int trucksNumber = int.Parse(Console.ReadLine());

            int totalToysNumber = puzzlesNumber 
                + talkingDollsNumber 
                + teddyBearsNumber 
                + minionsNumber 
                + trucksNumber;

            double totalPrice = (puzzlesNumber * puzzlePrice)
                + (talkingDollsNumber * talkingDollPrice)
                + (teddyBearsNumber * teddyBearPrice)
                + (minionsNumber * minionPrice)
                + (trucksNumber * truckPrice);

            if (totalToysNumber >= 50)
            {
                totalPrice = totalPrice - (totalPrice * bigOrderPercentageDiscount);
            }

            totalPrice = totalPrice - (totalPrice * rentPercentage);

            if (totalPrice >= tripPrice)
            {
                Console.WriteLine($"Yes! {totalPrice-tripPrice:F2} lv left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! {tripPrice-totalPrice:F2} lv needed.");
            }

        }
    }
}
