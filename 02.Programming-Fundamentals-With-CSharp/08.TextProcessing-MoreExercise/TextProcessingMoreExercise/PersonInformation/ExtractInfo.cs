namespace PersonInformation
{
    #region Using

    using System;

    #endregion

    internal class ExtractInfo
    {
        private static void Main(string[] args)
        {
            int linesNumber = int.Parse(Console.ReadLine());
            while (linesNumber > 0)
            {
                string line = Console.ReadLine() ?? string.Empty;

                int startIndex = line.IndexOf("@");
                int endIndex = line.IndexOf("|");
                string name = line.Substring(startIndex + 1, endIndex - startIndex - 1);

                startIndex = line.IndexOf("#");
                endIndex = line.IndexOf("*");
                string ages = line.Substring(startIndex + 1, endIndex - startIndex - 1);

                Console.WriteLine($"{name} is {ages} years old.");

                linesNumber--;
            }
        }
    }
}