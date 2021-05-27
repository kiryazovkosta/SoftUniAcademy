namespace KaminoFactory
{
    using System;
    using System.Linq;

    public class KaminoFactoryMain
    {
        public static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(length)));
            string input = Console.ReadLine();

            int[] dna = new int[length];
            int dnaSum = 0;
            int dnaCount = -1;
            int dnaStartIndex = -1;
            int dnaSample = 0;

            int sampleCounter = 0;
            while (input != "Clone them!")
            {
                sampleCounter++;
                int[] currentDna = input.Split("!", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(int.Parse)
                                    .ToArray();
                int currentCount = 0;
                int currentStartIndex = 0;
                int currentDnaSum = 0;

                int count = 0;
                for (int i = 0; i < currentDna.Length; i++)
                {
                    if (currentDna[i] != 1)
                    {
                        count = 0;
                        continue;
                    }

                    count++;
                    if (count > currentCount)
                    {
                        currentCount = count;
                        currentStartIndex = i - currentCount + 1;
                    }
                }

                currentDnaSum = currentDna.Sum();

                if ((currentCount > dnaCount)
                    || (currentCount == dnaCount && currentStartIndex < dnaStartIndex)
                    || (currentCount == dnaCount && currentStartIndex == dnaStartIndex && currentDnaSum > dnaSum))
                {
                    dna = currentDna;
                    dnaCount = currentCount;
                    dnaStartIndex = currentStartIndex;
                    dnaSum = currentDnaSum;
                    dnaSample = sampleCounter;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Best DNA sample {dnaSample} with sum: {dnaSum}.");
            Console.WriteLine(string.Join(" ", dna));
        }
    }
}