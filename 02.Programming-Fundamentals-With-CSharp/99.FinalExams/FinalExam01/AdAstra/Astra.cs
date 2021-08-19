namespace AdAstra
{
    using System;
    using System.Text.RegularExpressions;

    public class Astra
    {
        static void Main(string[] args)
        {
            string pattern =
                @"(\||#{1})(?<name>[A-Za-z ]+)\1(?<date>[0-9]{2}\/[0-9]{2}\/[0-9]{2})\1(?<calories>[0-9]{1,4}|10000)\1";

            string text = Console.ReadLine();
            MatchCollection foods = Regex.Matches(text, pattern);

            long totalCalories = 0;
            foreach (Match food in foods)
            {
                totalCalories += int.Parse(food.Groups["calories"].Value);
            }

            Console.WriteLine($"You have food to last you for: {totalCalories / 2000} days!");
            foreach (Match food in foods)
            {
                Console.WriteLine(
                    $"Item: {food.Groups["name"].Value}, Best before: {food.Groups["date"].Value}, Nutrition: {food.Groups["calories"].Value}");
            }
        }
    }
}
