namespace CharactersInRange
{
    #region Using

    using System;

    #endregion

    public class Range
    {
        public static void Main(string[] args)
        {
            char beginCharacter = char.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(beginCharacter)));
            char endCharacter = char.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(endCharacter)));

            PrintCharsInRange(beginCharacter, endCharacter);

        }

        private static void PrintCharsInRange(char beginCharacter, char endCharacter)
        {
            if (beginCharacter <= endCharacter)
            {
                PrintToBigger(beginCharacter, endCharacter);
            }
            else
            {
                PrintToSmaller(beginCharacter, endCharacter);
            }
        }

        private static void PrintToSmaller(char beginCharacter, char endCharacter)
        {
            for (int i = endCharacter + 1; i < beginCharacter; i++)
            {
                Console.Write($"{(char) i} ");
            }
        }

        private static void PrintToBigger(char beginCharacter, char endCharacter)
        {
            for (var i = beginCharacter + 1; i < endCharacter; i++)
            {
                Console.Write($"{(char) i} ");
            }
        }
    }
}