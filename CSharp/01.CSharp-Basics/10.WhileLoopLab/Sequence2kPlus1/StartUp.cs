namespace Sequence2kPlus1
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int n = 1;
            while (number >= n)
            {
                Console.WriteLine(n);
                n = n * 2 + 1;
            }
        }
    }
}
