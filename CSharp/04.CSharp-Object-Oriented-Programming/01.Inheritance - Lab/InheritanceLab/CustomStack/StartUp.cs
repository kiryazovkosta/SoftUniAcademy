namespace CustomStack
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            StackOfStrings stack = new StackOfStrings();
            Console.WriteLine(stack.Count);
            Console.WriteLine(stack.IsEmpty());
            var colors = new Stack<string>(new List<string>() {"blue", "green", "red"});
            stack.AddRange(colors);
            Console.WriteLine(stack.Count);
            Console.WriteLine(stack.IsEmpty());
        }
    }
}