namespace WildFarm
{
    using System;
    using System.Collections.Generic;
    using WildFarm.Factories;
    using WildFarm.Models.Animals;
    using WildFarm.Models.Animals.Mammals.Felines;
    using WildFarm.Models.Foods;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var animals = new List<Animal>();
            var animalsCreator = new AnimalCreatorFactory();
            var foodCreator = new FoodCreatorFactory();

            string input = Console.ReadLine();
            while (input != "End")
            {
                var data = input?.Split(" ");
                Animal animal = animalsCreator.Create(data[0], data);
                
                input = Console.ReadLine();
                data = input?.Split(" ");
                Food food = foodCreator.Create(int.Parse(data[1]), data[0]);

                Console.WriteLine(animal.AskForFood());
                var canEat = animal.CanEat(food);
                if (canEat)
                {
                    animal.IncreaseWeight(food.Quantity);
                }
                else
                {
                    Console.WriteLine($"{animal.GetType().Name} does not eat {food.GetType().Name}!");
                }

                animals.Add(animal);

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
