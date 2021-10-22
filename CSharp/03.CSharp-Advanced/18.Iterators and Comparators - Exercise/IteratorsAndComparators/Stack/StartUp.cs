using System;

namespace Stack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Stack<string> myStack = new Stack<string>();

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] data = input.Split(new char[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];
                if (command == "Push")
                {
                    for (int i = 1; i < data.Length; i++)
                    {
                        myStack.Push(data[i]);
                    }
                }
                else
                {
                    if (myStack.Count > 0)
                    {
                        myStack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("No elements");
                    }
                }

                input = Console.ReadLine();
            }

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
