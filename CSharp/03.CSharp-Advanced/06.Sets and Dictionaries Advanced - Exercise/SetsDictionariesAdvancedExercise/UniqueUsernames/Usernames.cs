namespace UniqueUsernames
{
    using System;
    using System.Collections.Generic;

    public class Usernames
    {
        static void Main(string[] args)
        {
            HashSet<string> usernames = new HashSet<string>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string name = Console.ReadLine();
                usernames.Add(name);
            }

            foreach (string username in usernames)
            {
                Console.WriteLine(username);
            }
        }
    }
}
