namespace ArrayRotation
{
    using System;
    public class ArrayRotationMain
    {
        public static void Main(string[] args)
        {
            string[] words = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries) ?? new string[] { };
            int rotation = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            int length = words.Length;
            for (int i = 0; i < rotation; i++)
            {
                string first = words[0];
                for (int j = 0; j < length - 1; j++)
                {
                    words[j] = words[j + 1];
                }

                words[length - 1] = first;
            }

            Console.WriteLine(string.Join(" ", words));
        }
    }
}
