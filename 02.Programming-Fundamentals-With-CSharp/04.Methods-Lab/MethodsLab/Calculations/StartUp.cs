namespace Calculations
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int a = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(a)));
            int b = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(b)));

            int result = 0;
            switch (command)
            {
                case "add":
                    result = Add(a, b);
                    break;

                case "multiply":
                    result = Multiply(a, b);
                    break;

                case "subtract":
                    result = Subtract(a, b);
                    break;

                case "divide":
                    result = Divide(a, b);
                    break;

                default:
                    break;
            }

            Console.WriteLine(result);
        }

        private static int Divide(int a, int b)
        {
            return a / b;
        }

        private static int Subtract(int a, int b)
        {
            return a - b;
        }

        private static int Multiply(int a, int b)
        {
            return a * b;
        }

        private static int Add(int a, int b)
        {
            return a + b;
        }
    }
}
