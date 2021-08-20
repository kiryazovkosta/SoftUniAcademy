namespace CharsToString
{
    using System;
    public class CharsToStringMain
    {
        public static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            char c = char.Parse(Console.ReadLine());

            string output = string.Empty;
            output += a;
            output += b;
            output += c;
            Console.WriteLine(output);
        }
    }
}
