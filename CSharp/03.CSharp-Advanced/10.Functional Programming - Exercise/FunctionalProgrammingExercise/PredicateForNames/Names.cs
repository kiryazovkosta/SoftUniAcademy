namespace PredicateForNames
{
    using System;
    using System.Linq;
    public class Names
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());

            var names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(name => name.Length <= length);
            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
