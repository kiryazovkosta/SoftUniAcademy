namespace Task02
{
    using System;
    using System.Text.RegularExpressions;

    public class ValidInput
    {
        static void Main(string[] args)
        {
            string pattern = @"\|(?<name>[A-Z]{4,})\|:\#(?<title>[A-Za-z]+ [A-Za-z]+)\#";

            int count = int.Parse(Console.ReadLine());
            for (int i = 1; i <= count; i++)
            {
                string input = Console.ReadLine();

                if (Regex.IsMatch(input, pattern))
                {
                    Match match = Regex.Match(input, pattern);
                    string boss = match.Groups["name"].Value;
                    string title = match.Groups["title"].Value;

                    Console.WriteLine($"{boss}, The {title}");
                    Console.WriteLine($">> Strength: {boss.Length}");
                    Console.WriteLine($">> Armor: {title.Length}");
                }
                else
                {
                    Console.WriteLine($"Access denied!");
                }
            }
        }
    }
}
