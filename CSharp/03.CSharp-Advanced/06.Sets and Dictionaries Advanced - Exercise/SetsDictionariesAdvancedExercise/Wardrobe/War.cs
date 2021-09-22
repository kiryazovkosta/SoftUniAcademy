namespace Wardrobe
{
    using System;
    using System.Collections.Generic;

    public class War
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> colors = new Dictionary<string, Dictionary<string, int>>();

            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] data = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries);
                string color = data[0].Trim();
                string[] dresses = data[1].Trim().Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (!colors.ContainsKey(color))
                {
                    colors.Add(color, new Dictionary<string, int>());
                }

                foreach (var dress in dresses)
                {
                    if (!colors[color].ContainsKey(dress))
                    {
                        colors[color].Add(dress, 0);
                    }

                    colors[color][dress]++;
                }
            }

            string[] clothings = Console.ReadLine().Split(" ");
            string myColor = clothings[0];
            string myDress = clothings[1];
            foreach (var color in colors)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var dress in color.Value)
                {
                    if (color.Key == myColor && dress.Key == myDress)
                    {
                        Console.WriteLine($"* {dress.Key} - {dress.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {dress.Key} - {dress.Value}");
                    }
                }
            }
        }
    }
}
