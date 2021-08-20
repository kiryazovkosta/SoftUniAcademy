namespace PrintAndSum
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int startNubmer = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(startNubmer)));
            int endNubmer = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(endNubmer)));
            long sum = 0;
            for (int i = startNubmer; i <= endNubmer; i++)
            {
                Console.Write($"{1} ");
                sum += i;
            }

            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
