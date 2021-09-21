namespace SimpleTextEditor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class Editor
    {
        private static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Stack<string> history = new Stack<string>();

            StringBuilder text = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (command[0] == "1")
                {
                    history.Push(text.ToString());
                    string argument = command[1];
                    text.Append(argument);
                }
                else if (command[0] == "2")
                {
                    history.Push(text.ToString());
                    int size = int.Parse(command[1]);
                    while (size > 0)
                    {
                        text.Remove(text.Length - 1, 1);
                        size--;
                    }
                }
                else if (command[0] == "3")
                {
                    int index = int.Parse(command[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (command[0] == "4")
                {
                    text.Clear();
                    text.Append(history.Pop());
                }
            }
        }
    }
}