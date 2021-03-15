using System;

namespace Pets
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int food = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double dogFoodPerDay = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double catFoodPerDay = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double turtleFoodPerDay = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            double totalFood = (days * dogFoodPerDay)
                               + (days * catFoodPerDay)
                               + (days * (turtleFoodPerDay / 1000));
            if (food >= totalFood)
            {
                Console.WriteLine($"{Math.Floor(food-totalFood)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(totalFood-food)} more kilos of food are needed.");
            }
        }
    }
}
