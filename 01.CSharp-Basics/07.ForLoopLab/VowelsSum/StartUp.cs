namespace VowelsSum
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine().ToLower();
            int sum = 0;
            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];
                switch (symbol)
                {
                    case 'a':
                        sum += 1;
                        break;
                    case 'e':
                        sum += 2;
                        break;
                    case 'i':
                        sum += 3;
                        break;
                    case 'o':
                        sum += 4;
                        break;
                    case 'u':
                        sum += 5;
                        break;

                    default:
                        break;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
