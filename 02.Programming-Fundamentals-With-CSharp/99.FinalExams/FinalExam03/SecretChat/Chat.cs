namespace SecretChat
{
    using System;
    public class Chat
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string input = Console.ReadLine();
            while (input != "Reveal")
            {
                string[] data = input.Split(":|:", StringSplitOptions.RemoveEmptyEntries);
                string command = data[0].Trim();
                switch (command)
                {
                    case "InsertSpace":
                        int index = int.Parse(data[1].Trim());
                        message = message.Insert(index, " ");
                        Console.WriteLine(message);
                        break;

                    case "Reverse":
                        string substring = data[1];
                        index = message.IndexOf(substring);
                        if (index >= 0)
                        {
                            message = message.Remove(index, substring.Length);
                            for (int i = substring.Length - 1; i >= 0; i--)
                            {
                                message += substring[i];
                            }

                            Console.WriteLine(message);
                        }
                        else
                        {
                            Console.WriteLine($"error");
                        }
                        break;

                    case "ChangeAll":
                        substring = data[1];
                        string replacement = data[2];
                        message = message.Replace(substring, replacement);
                        Console.WriteLine(message);
                        break;

                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
