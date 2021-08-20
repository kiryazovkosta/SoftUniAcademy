namespace GreaterOfTwoValues
{
    #region Using

    using System;

    #endregion

    public class Greater
    {
        private static void Main(string[] args)
        {
            string type = Console.ReadLine();

            if (type == "int")
            {
                int first = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(first)));
                int second = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(second)));
                Console.WriteLine(GetMax(first, second));
            }
            else if (type == "char")
            {
                char first = char.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(first)));
                char second = char.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(second)));
                Console.WriteLine(GetMax(first, second));
            }
            else
            {
                string first = Console.ReadLine();
                string second = Console.ReadLine();
                Console.WriteLine(GetMax(first, second));
            }
        }

        private static int GetMax(int first, int second)
        {
            if (first >= second)
            {
                return first;
            }

            return second;
        }

        private static char GetMax(char first, char second)
        {
            if (first >= second)
            {
                return first;
            }

            return second;
        }

        private static string GetMax(string first, string second)
        {
            int length = first.Length >= second.Length ? second.Length : first.Length;
            for (int i = 0; i < length; i++)
            {
                if (first[i] > second[i])
                {
                    return first;
                }
                else if (second[i] > first[i])
                {
                    return second;
                }
            }

            if (first.Length == second.Length)
            {
                return first;
            }
            else
            {
                if (first.Length < second.Length)
                {
                    return first;
                }

                return second;
            }
        }
    }
}