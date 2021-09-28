namespace CountUppercaseWords
{
    using System;
    using System.Linq;

    public class Count
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine() ?? string.Empty;
            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var capitalWords = words.Where(w => char.IsUpper(w[0])).ToList();
            foreach (var word in capitalWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}