namespace RepeatStrings
{
    using System;
    using System.Text;

    public class Repeat
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            StringBuilder output = new StringBuilder();
            foreach (var word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    output.Append(word);
                }
            }

            Console.WriteLine(output.ToString());
        }
    }
}
