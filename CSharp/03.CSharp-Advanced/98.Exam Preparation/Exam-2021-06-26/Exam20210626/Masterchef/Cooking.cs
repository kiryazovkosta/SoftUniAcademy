namespace Masterchef
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Cooking
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dishes = new Dictionary<string, int>()
            {
                { "Dipping sauce", 0 },
                { "Green salad", 0 },
                { "Chocolate cake", 0 },
                { "Lobster", 0 },
            };

            var ingredients = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            var freshness = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));

            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                int ingredient = ingredients.Peek();
                int fresh = freshness.Peek();
                int totalFreshness = fresh * ingredient;

                if (totalFreshness == 150)
                {
                    dishes["Dipping sauce"]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if(totalFreshness == 250)
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
                else if (ingredient == 0)
                {
                    ingredients.Dequeue();
                }
                else
                {
                    freshness.Pop();
                    ingredients.Dequeue();
                    ingredient += 5;
                    ingredients.Enqueue(ingredient);
                }
            }

            if (dishes.Values.All(d => d > 0))
            {
                Console.WriteLine($"Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine($"You were voted off. Better luck next year.");
            }

            if (ingredients.Sum() > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var dish in dishes.OrderBy(d => d.Key))
            {
                if (dish.Value > 0)
                {
                    Console.WriteLine($" # {dish.Key} --> {dish.Value}");
                }
            }
        }
    }
}
