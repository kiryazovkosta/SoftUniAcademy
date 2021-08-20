namespace ReverseArrayOfStrings
{
    using System;

    public class ReverseArrayOfStringsMain
    {
        public static void Main(string[] args)
        {
            string[] words = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries) ?? new string[] { };
            for (int i = 0, j = words.Length - 1; i < words.Length / 2; i++, j--)
            {
                string temp = words[i];
                words[i] = words[j];
                words[j] = temp;
            }

            Console.WriteLine(string.Join(" ", words));
        }
    }
}
