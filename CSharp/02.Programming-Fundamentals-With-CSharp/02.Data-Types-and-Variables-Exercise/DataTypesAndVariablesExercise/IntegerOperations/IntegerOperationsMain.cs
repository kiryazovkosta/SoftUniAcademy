namespace IntegerOperations
{
    using System;
    public class IntegerOperationsMain
    {
        public static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());

            long result = a + b;
            result /= c;
            result *= d;
            Console.WriteLine(result);
        }
    }
}
