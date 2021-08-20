namespace ReverseStrings
{
    using System;
    using System.Text;

    public class Reverse
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "end")
            {
                StringBuilder reversedInput = new StringBuilder();
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    reversedInput.Append(input[i]);
                }

                Console.WriteLine($"{input} = {reversedInput.ToString()}");
                input = Console.ReadLine();
            }
        }
    }
}