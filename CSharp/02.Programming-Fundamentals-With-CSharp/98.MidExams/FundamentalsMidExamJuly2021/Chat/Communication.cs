namespace Chat
{
    using System;
    using System.Collections.Generic;
    public class Communication
    {
        static void Main(string[] args)
        {
            List<string> messages = new List<string>();

            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] operation = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = operation[0];
                switch (command)
                {
                    case "Chat":
                        string message = operation[1];
                        messages.Add(message);
                        break;

                    case "Delete":
                        message = operation[1];
                        if (messages.Contains(message))
                        {
                            messages.Remove(message);
                        }

                        break;

                    case "Edit":
                        message = operation[1];
                        string newMessage = operation[2];
                        if (messages.Contains(message))
                        {
                            int index = messages.IndexOf(message);
                            messages[index] = newMessage;
                        }

                        break;

                    case "Pin":
                        message = operation[1];
                        if (messages.Contains(message))
                        {
                            int index = messages.IndexOf(message);
                            messages.RemoveAt(index);
                            messages.Add(message);
                        }

                        break;

                    case "Spam":
                        for (int i = 1; i < operation.Length; i++)
                        {
                            messages.Add(operation[i]);
                        }

                        break;

                    default:
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, messages));
        }
    }
}
