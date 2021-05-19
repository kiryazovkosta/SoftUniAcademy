namespace PrintAndSum
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(start)));
            int end = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(end)));
            int sum = 0;
            for (int i = start; i <= end ; i++)
            {
                Console.Write($"{i} ");
                sum += i;
            }
            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
