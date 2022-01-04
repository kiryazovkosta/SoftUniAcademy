using System;
using System.Collections.Generic;
using System.Linq;

namespace Blacksmith
{



    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> swords = new Dictionary<string, int>()
            {
                { "Gladius", 0 },
                { "Shamshir", 0 },
                { "Katana", 0 },
                { "Sabre", 0 },
                { "Broadsword", 0 }
            };

            Queue<int> steels = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> carbons = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            CreateSwords(swords, steels, carbons);
            PrintNumberOfSwords(swords);
            PrintSteels(steels);
            PrintCarbons(carbons);
            PrintSworda(swords);
        }

        private static void PrintSworda(Dictionary<string, int> swords)
        {
            foreach (var sword in swords.Where(s => s.Value > 0).OrderBy(s => s.Key))
            {
                Console.WriteLine($"{sword.Key}: {sword.Value}");
            }
        }

        private static void CreateSwords(Dictionary<string, int> swords, Queue<int> steels, Stack<int> carbons)
        {
            while (steels.Count > 0 && carbons.Count > 0)
            {
                int steel = steels.Dequeue();
                int carbon = carbons.Pop();

                int sum = steel + carbon;
                if (sum == 70)
                {
                    swords["Gladius"]++;
                }
                else if (sum == 80)
                {
                    swords["Shamshir"]++;
                }
                else if (sum == 90)
                {
                    swords["Katana"]++;
                }
                else if (sum == 110)
                {
                    swords["Sabre"]++;
                }
                else if (sum == 150)
                {
                    swords["Broadsword"]++;
                }
                else
                {
                    carbon += 5;
                    carbons.Push(carbon);
                }
            }
        }

        private static void PrintCarbons(Stack<int> carbons)
        {
            if (carbons.Any())
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbons)}");
            }
            else
            {
                Console.WriteLine("Carbon left: none");
            }
        }

        private static void PrintSteels(Queue<int> steels)
        {
            if (steels.Any())
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steels)}");
            }
            else
            {
                Console.WriteLine("Steel left: none");
            }
        }

        private static void PrintNumberOfSwords(Dictionary<string, int> swords)
        {
            if (swords.Any(s => s.Value > 0))
            {
                Console.WriteLine($"You have forged {swords.Sum(s => s.Value)} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
        }
    }
}
