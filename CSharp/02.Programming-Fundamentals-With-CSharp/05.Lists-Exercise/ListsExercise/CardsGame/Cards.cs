namespace CardsGame
{
    #region Using

    using System;
    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class Cards
    {
        private static void Main(string[] args)
        {
            List<int> first = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()
                                ?? new List<int>();
            List<int> second = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()
                                ?? new List<int>();

            while (true)
            {
                int firstPlayerCard = first.First();
                int secondPlayerCard = second.First();

                first.RemoveAt(0);
                second.RemoveAt(0);

                if (firstPlayerCard > secondPlayerCard)
                {
                    first.Add(firstPlayerCard);
                    first.Add(secondPlayerCard);
                }
                else if (secondPlayerCard > firstPlayerCard)
                {
                    second.Add(secondPlayerCard);
                    second.Add(firstPlayerCard);
                }

                if (first.Count == 0)
                {
                    Console.WriteLine($"Second player wins! Sum: {second.Sum()}");
                    break;
                }

                if (second.Count == 0)
                {
                    Console.WriteLine($"First player wins! Sum: {first.Sum()}");
                    break;
                }
            }
        }
    }
}