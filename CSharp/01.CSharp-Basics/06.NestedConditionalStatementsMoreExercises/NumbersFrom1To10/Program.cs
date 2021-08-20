namespace NumbersFrom1To10
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            int current = 1;
            int max = 10;
            while (current <= max)
            {
                Console.WriteLine(current);
                current++;
            }
        }
    }
}
