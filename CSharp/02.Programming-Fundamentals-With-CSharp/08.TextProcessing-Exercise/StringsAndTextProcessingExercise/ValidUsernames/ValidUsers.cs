namespace ValidUsernames
{
    using System;
    using System.Collections.Generic;

    public class ValidUsers
    {
        static void Main(string[] args)
        {
            List<string> validNames = new List<string>();
            string[] names = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            foreach (string name in names)
            {
                if (IsValidUserName(name))
                {
                    validNames.Add(name);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, validNames));
        }

        private static bool IsValidUserName(string name)
        {
            if (name.Length < 3 || name.Length > 16)
            {
                return false;
            }

            foreach (char symbol in name)
            {
                if (char.IsDigit(symbol) == false 
                    && char.IsLetter(symbol) == false 
                    && symbol != '-' 
                    && symbol != '_')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
