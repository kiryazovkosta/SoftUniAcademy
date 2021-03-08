namespace PetShop
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            int dogs = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int animals = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            double dogsFoodPrice = dogs * 2.5;
            int animalsFoodPrice = animals * 4;

            double totalPrice = dogsFoodPrice + animalsFoodPrice;
            Console.WriteLine($"{totalPrice} lv.");
        }
    }
}
