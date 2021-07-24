namespace Substring
{
    using System;
    public class Sub
    {
        static void Main(string[] args)
        {
            string pattern = Console.ReadLine();
            string text = Console.ReadLine();

            int index = text.IndexOf(pattern);
            while (index >= 0)
            {
                text = text.Remove(index, pattern.Length);
                index = text.IndexOf(pattern);
            }

            Console.WriteLine(text);
        }
    }
}
