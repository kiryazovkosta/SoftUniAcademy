using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoryGame
{
    public class Games
    {
        static void Main(string[] args)
        {
            int moves = 0;
            List<string> elements = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList()
                ?? new List<string>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                moves++;
                int[] indexes = input?.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray()
                    ?? new int[]{ };

                int firstIndex = indexes[0];
                int secondIndex = indexes[1];

                if ( (firstIndex == secondIndex)
                    || (firstIndex < 0 || firstIndex > elements.Count - 1)
                    || (secondIndex < 0 || secondIndex > elements.Count - 1))
                {
                    string element = $"-{moves}a";
                    int middle = elements.Count / 2;
                    elements.InsertRange(middle, new List<string>() {element, element});
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                else
                {
                    if (elements[firstIndex] == elements[secondIndex])
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {elements[firstIndex]}!");
                        if (firstIndex > secondIndex)
                        {
                            elements.RemoveAt(firstIndex);
                            elements.RemoveAt(secondIndex);
                        }
                        else
                        {
                            elements.RemoveAt(secondIndex);
                            elements.RemoveAt(firstIndex);
                        }


                    }
                    else
                    {
                        Console.WriteLine($"Try again!");
                    }

                    if (elements.Count == 0)
                    {
                        break;
                    }
                }


                input = Console.ReadLine();
            }

            if (elements.Count == 0)
            {
                Console.WriteLine($"You have won in {moves} turns!");
            }
            else
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", elements));
            }
        }
    }
}
