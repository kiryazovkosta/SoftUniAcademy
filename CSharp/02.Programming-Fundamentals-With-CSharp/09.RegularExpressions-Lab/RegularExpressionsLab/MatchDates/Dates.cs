namespace MatchDates
{
    #region Using

    using System;
    using System.Text.RegularExpressions;

    #endregion

    internal class Dates
    {
        private static void Main(string[] args)
        {
            var datePattern = @"\b(?<day>[0-9]{2})([-.\/])(?<month>[A-Z][a-z]{2})\1(?<year>[0-9]{4})\b";

            var text = Console.ReadLine() ?? string.Empty;
            var dates = Regex.Matches(text, datePattern);

            foreach (Match date in dates)
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}