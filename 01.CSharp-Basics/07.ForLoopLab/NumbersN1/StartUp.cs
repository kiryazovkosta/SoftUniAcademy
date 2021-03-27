namespace NumbersN1
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = number; i > 0; i--)
            {
                Console.WriteLine(i);
            }
        }
    }
}
