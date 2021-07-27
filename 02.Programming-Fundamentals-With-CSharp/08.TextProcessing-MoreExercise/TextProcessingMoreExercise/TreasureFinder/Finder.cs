namespace TreasureFinder
{
    #region Using

    using System;
    using System.Linq;
    using System.Text;

    #endregion

    internal class Finder
    {
        private static void Main(string[] args)
        {
            int[] key = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            string input = Console.ReadLine();
            while (input != "find")
            {
                StringBuilder decrypted = new StringBuilder();
                int j = 0;

                for (int i = 0; i < input?.Length; i++)
                {
                    decrypted.Append((char) (input[i] - key[j]));

                    j++;
                    if (j == key.Length)
                    {
                        j = 0;
                    }
                }

                string message = decrypted.ToString();
                int startIndex = message.IndexOf("&");
                int endIndex = message.IndexOf("&", startIndex + 1);
                string type = message.Substring(startIndex + 1, endIndex - startIndex - 1);

                startIndex = message.IndexOf("<");
                endIndex = message.IndexOf(">", startIndex);
                string coordinates = message.Substring(startIndex + 1, endIndex - startIndex - 1);

                Console.WriteLine($"Found {type} at {coordinates}");

                input = Console.ReadLine();
            }
        }
    }
}