namespace LettersCombinations
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            char start = char.Parse(Console.ReadLine());
            char end = char.Parse(Console.ReadLine());
            char exclude = char.Parse(Console.ReadLine());

            int counter = 0;
            for (char i = start; i <= end; i++)
            {
                for (char j = start; j <= end; j++)
                {
                    for (char k = start; k <= end; k++)
                    {
                        if (i != exclude &&  j != exclude && k != exclude)
                        {
                            counter++;
                            Console.Write($"{i}{j}{k} ");
                        }
                    }
                }
            }

            Console.Write(counter);
        }
    }
}