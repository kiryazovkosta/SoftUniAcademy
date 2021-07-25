namespace ReplaceRepeatingChars
{
    using System;

    public class RepeatingChars
    {

        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == text[i + 1])
                {
                    text = text.Remove(i + 1, 1);
                    i = -1;
                }
            }

            Console.WriteLine(text);
        }
    }
}
