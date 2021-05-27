namespace CommonElements
{
    using System;
    public class CommonElementsMain
    {
        public static void Main(string[] args)
        {
            string[] first = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries) ?? new string[] { };
            string[] second = Console.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries) ?? new string[] { };

            for (int i = 0; i < second.Length; i++)
            {
                for (int j = 0; j < first.Length; j++)
                {
                    if (second[i] == first[j])
                    {
                        Console.Write($"{second[i]} ");
                        break;
                    }
                }
            }
        }
    }
}