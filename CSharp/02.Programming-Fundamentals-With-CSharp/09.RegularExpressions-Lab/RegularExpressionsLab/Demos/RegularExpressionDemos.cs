namespace Demos
{
    #region Using

    using System;
    using System.Text.RegularExpressions;

    #endregion

    internal class RegularExpressionDemos
    {
        private static void Main(string[] args)
        {
            Regex regex = new Regex(@"([A-Z][a-z]+) ([A-Z][a-z]+)");
            string input = @"John Smith
                Dimitrichko
                Pesho Petrov
                gosho goshkata
                sdfsdfsdf sdf
                asdsadasdasdasdas
                asdd
                as
                asdasdsad asd as das dads d

                John S

                AbAbzAzA
                Jasdsadasdddddddddasdasdasdasdasdasdassdasdasdasdasd

                Ja";
            Match match = regex.Match(input);
            Console.WriteLine($"{match.Value} {match.Success} {match.Index} {match.NextMatch()?.Value}");

            var groups = match.Groups;
            foreach (var group in groups.Values)
            {
                Console.WriteLine($"{group.Name}");
                Console.WriteLine($"{group.Value}");
            }
        }
    }
}