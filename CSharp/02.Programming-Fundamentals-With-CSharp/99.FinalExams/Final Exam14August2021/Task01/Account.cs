namespace Task01
{
    using System;
    using System.Text;

    public class Account
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();

            string input = Console.ReadLine();
            while (input != "Sign up")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];
                if (command == "Case")
                {
                    string type = data[1];
                    userName = Case(userName, type);
                    Console.WriteLine(userName);
                }
                else if (command == "Reverse")
                {
                    int startIndex = int.Parse(data[1]);
                    int endIndex = int.Parse(data[2]);
                    Reverse(userName, startIndex, endIndex);
                }
                else if (command == "Cut")
                {
                    string pattern = data[1];
                    userName = Cut(userName, pattern);
                }
                else if (command == "Replace")
                {
                    char symbol = char.Parse(data[1]);
                    userName = Replace(userName, symbol);
                    Console.WriteLine(userName);
                }
                else if (command == "Check")
                {
                    char symbol = char.Parse(data[1]);
                    Check(userName, symbol);
                }

                input = Console.ReadLine();
            }
        }

        private static void Check(string userName, char symbol)
        {
            bool isValid = false;
            foreach (char c in userName)
            {
                if (symbol == c)
                {
                    isValid = true;
                    break;
                }
            }

            if (isValid)
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine($"Your username must contain {symbol}.");
            }
        }

        private static string Replace(string userName, char symbol)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < userName.Length; i++)
            {
                char value = userName[i];
                if (value == symbol)
                {
                    value = '*';
                }

                result.Append(value);
            }

            userName = result.ToString();
            return userName;
        }

        private static string Cut(string userName, string pattern)
        {
            int index = userName.IndexOf(pattern);
            if (index >= 0)
            {
                userName = userName.Replace(pattern, string.Empty);
                Console.WriteLine(userName);
            }
            else
            {
                Console.WriteLine($"The word {userName} doesn't contain {pattern}.");
            }

            return userName;
        }

        private static void Reverse(string userName, int startIndex, int endIndex)
        {
            if (startIndex >= 0 && endIndex < userName.Length)
            {
                for (int i = endIndex; i >= startIndex; i--)
                {
                    Console.Write(userName[i]);
                }
                Console.WriteLine();
            }
        }

        private static string Case(string userName, string type)
        {
            if (type == "lower")
            {
                userName = userName.ToLower();
            }
            else if (type == "upper")
            {
                userName = userName.ToUpper();
            }

            return userName;
        }
    }
}
