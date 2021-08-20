namespace MatchPhoneNumber
{
    #region Using

    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    #endregion

    internal class PhoneNumber
    {
        private static void Main(string[] args)
        {
            var phonePattern = @"\+359([ -])2\1[0-9]{3}\1[0-9]{4}\b";
            var text = Console.ReadLine() ?? string.Empty;
            var phoneMatches = Regex.Matches(text, phonePattern);

            var phones = phoneMatches.Select(p => p.Value.Trim()).ToArray();
            Console.WriteLine(string.Join(", ", phones));
        }
    }
}