using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Queue<int> effects = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Stack<int> casings = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));

            int cherryBombs = 0;
            int daturaBombs = 0;
            int smokeBombs = 0;

            while (effects.Count > 0 && casings.Count > 0)
            {
                int effect = effects.Dequeue();
                int casing = casings.Pop();

                int sum = effect + casing;

                if (sum == 40)
                {
                    daturaBombs++;
                }
                else if (sum == 60)
                {
                    cherryBombs++;
                }
                else if (sum == 120)
                {
                    smokeBombs++;
                }
                else
                {
                    while (true)
                    {
                        sum -= 5;
                        if (sum == 40)
                        {
                            daturaBombs++;
                            break;
                        }
                        else if (sum == 60)
                        {
                            cherryBombs++;
                            break;
                        }
                        else if (sum == 120)
                        {
                            smokeBombs++;
                            break;
                        }
                    }
                }

                if (EnoughtBombs(cherryBombs, daturaBombs, smokeBombs))
                {
                    break;
                }
            }

            if (EnoughtBombs(cherryBombs, daturaBombs, smokeBombs))
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            string elements = "empty";
            if (effects.Count > 0)
            {
                elements = string.Join(", ", effects);
            }

            Console.WriteLine($"Bomb Effects: {elements}");

            elements = "empty";
            if (casings.Count > 0)
            {
                elements = string.Join(", ", casings);
            }

            Console.WriteLine($"Bomb Casings: {elements}");

            Console.WriteLine($"Cherry Bombs: {cherryBombs}");
            Console.WriteLine($"Datura Bombs: {daturaBombs}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeBombs}");



        }

        private static bool EnoughtBombs(int cherryBombs, int daturaBombs, int smokeBombs)
        {
            return cherryBombs >= 3 && daturaBombs >= 3 && smokeBombs >= 3;
        }
    }
}
