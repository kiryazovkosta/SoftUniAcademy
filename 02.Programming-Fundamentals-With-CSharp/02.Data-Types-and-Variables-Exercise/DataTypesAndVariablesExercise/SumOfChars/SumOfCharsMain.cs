namespace SumOfChars
{
    using System;
    public class SumOfCharsMain
    {
        public static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            long charsSum = 0;
            for (int i = 1; i <= numberOfLines; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                charsSum += (int)symbol;
            }

            Console.WriteLine($"The sum equals: {charsSum}");
        }
    }
}
