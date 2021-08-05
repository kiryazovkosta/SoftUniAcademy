namespace MatchFullName
{
    #region Using

    using System;
    using System.Text.RegularExpressions;

    #endregion

    internal class FullName
    {
        private static void Main(string[] args)
        {
            var fullNamePattern = @"\b([A-Z][a-z]+) ([A-Z][a-z]+)\b";
            var text = Console.ReadLine() ?? string.Empty;

            var names = Regex.Matches(text, fullNamePattern);
            foreach (Match name in names)
            {
                Console.Write(name.Value + " ");
            }

            Console.WriteLine();
        }
    }
}