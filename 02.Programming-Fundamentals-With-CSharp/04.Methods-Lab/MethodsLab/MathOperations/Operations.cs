namespace MathOperations
{
    #region Using

    using System;

    #endregion

    public class Operations
    {
        private static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(a)));
            string operation = Console.ReadLine();
            int b = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(b)));

            double result = Calculate(a, operation, b);
            Console.WriteLine(result);
        }

        private static double Calculate(int a, string operation, int b)
        {
            double result = operation switch
            {
                "+" => Add(a, b),
                "-" => Subtract(a, b),
                "*" => Multiply(a, b),
                "/" => Divide(a, b),
                _ => throw new ArgumentException(nameof(operation))
            };

            return result;
        }

        private static double Divide(int a, int b)
        {
            return a * 1.0 / b;
        }

        private static double Subtract(int a, int b)
        {
            return a - b;
        }

        private static double Multiply(int a, int b)
        {
            return a * b;
        }

        private static double Add(int a, int b)
        {
            return a + b;
        }
    }
}