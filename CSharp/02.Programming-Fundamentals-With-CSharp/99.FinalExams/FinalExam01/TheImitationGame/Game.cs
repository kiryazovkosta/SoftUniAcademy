namespace TheImitationGame
{
    using System;
    public class Game
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            string input = Console.ReadLine();
            while (input != "Decode")
            {
                string[] data = input.Split("|", StringSplitOptions.RemoveEmptyEntries);
                string command = data[0].Trim();
                if (command == "Move")
                {
                    int number = int.Parse(data[1]);
                    string first = message.Substring(0, number);
                    string second = message.Substring(number);
                    message = second + first;
                }
                else if (command == "Insert")
                {
                    int index = int.Parse(data[1]);
                    string value = data[2];
                    message = message.Insert(index, value);
                }
                else if (command == "ChangeAll")
                {
                    string substring = data[1];
                    string replacement = data[2];
                    message = message.Replace(substring, replacement);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}