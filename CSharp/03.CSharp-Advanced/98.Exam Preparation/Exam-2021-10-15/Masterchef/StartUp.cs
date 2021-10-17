namespace Masterchef
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var ingredients = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            var freshness = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));

            var dishes = new Dictionary<string, int>()
            {
                {"Dipping sauce", 0 },
                {"Green salad", 0 },
                {"Chocolate cake", 0 },
                {"Lobster", 0 }
            };

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                int ingredient = ingredients.Peek();
                int fresh = freshness.Peek();
                int totalFreshness = ingredient * fresh;

                if (ingredient == 0)
                {
                    ingredients.Dequeue();
                }
                else if (totalFreshness == 150)
                {
                    dishes["Dipping sauce"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (totalFreshness == 250)
                {
                    dishes["Green salad"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (totalFreshness == 300)
                {
                    dishes["Chocolate cake"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (totalFreshness == 400)
                {
                    dishes["Lobster"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else
                {
                    freshness.Pop();
                    ingredient += 5;
                    ingredients.Dequeue();
                    ingredients.Enqueue(ingredient);
                }
            }

            if (dishes.Values.All(v => v > 0))
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
                foreach (var dish in dishes.OrderBy(d => d.Key))
                {
                    Console.WriteLine($"# {dish.Key} --> {dish.Value}");
                }
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
                if (ingredients.Sum() > 0)
                {
                    Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
                }
                
                foreach (var dish in dishes.OrderBy(d => d.Key))
                {
                    if (dish.Value > 0)
                    {
                        Console.WriteLine($"# {dish.Key} --> {dish.Value}");
                    }
                    
                }
            }
        }
    }
}
