namespace EncryptSortAndPrintArray
{
    using System;

    public class EncryptSortAndPrintArrayMain
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(size)));
            int[] codes = new int[size];

            for (int i = 0; i < size; i++)
            {
                string text = Console.ReadLine() ?? string.Empty;
                int code = 0;
                for (int j = 0; j < text.Length; j++)
                {
                    char symbol = text[j];
                    if (IsVowel(symbol))
                    {
                        code += symbol * text.Length;
                    }
                    else
                    {
                        code += symbol / text.Length;
                    }
                }

                codes[i] = code;
            }

            Array.Sort(codes);
            Console.WriteLine(string.Join(Environment.NewLine, codes));
        }

        private static bool IsVowel(char letter)
        {
            switch (letter)
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                case 'A':
                case 'E':
                case 'I':
                case 'O':
                case 'U':
                    return true;
                default:
                    return false;
            }
        }
    }
}
