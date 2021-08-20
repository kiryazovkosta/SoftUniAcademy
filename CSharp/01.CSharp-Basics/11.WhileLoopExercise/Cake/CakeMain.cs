namespace Cake
{
    using System;
    public class CakeMain
    {
        public static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int size = a * b;
            string input = Console.ReadLine();
            while (input != "STOP")
            {
                int pieces = int.Parse(input);
                size -= pieces;
                if (size < 0)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            if (size >= 0)
            {
                Console.WriteLine($"{size} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(size)} pieces more.");
            }
        }
    }
}
