using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TheFightForGondor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int waves = int.Parse(Console.ReadLine());
            Queue<int> defenders = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            Stack<int> orcs = new Stack<int>();

            int wavesCount = 1;
            while (wavesCount <= waves && defenders.Count > 0)
            {
                string input = Console.ReadLine();

                if (wavesCount % 3 == 0)
                {
                    defenders.Enqueue(int.Parse(Console.ReadLine()));
                }

                orcs = new Stack<int>(input.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

                while (defenders.Count > 0 && orcs.Count > 0)
                {
                    int defender = defenders.Peek();
                    int orc = orcs.Pop();
                    if (defender >= orc)
                    {
                        defender -= orc;
                        defenders.Dequeue();
                    }
                    else
                    {
                        orc -= defender;
                        defenders.Dequeue();
                        orcs.Push(orc);
                        defender = 0;
                    }

                    if (defender > 0)
                    {
                        defenders.Enqueue(defender);
                        for (int i = 0; i < defenders.Count - 1; i++)
                        {
                            defenders.Enqueue(defenders.Dequeue());
                        }
                    }
                }

                wavesCount++;
            }

            if (defenders.Any())
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", defenders)}");
            }
            else
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine($"Orcs left: {string.Join(", ", orcs)}");
            }
        }
    }
}