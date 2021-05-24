namespace ConcatNames
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string last = Console.ReadLine();
            string delimeter = Console.ReadLine();
            Console.WriteLine($"{first}{delimeter}{last}");
        }
    }
}
