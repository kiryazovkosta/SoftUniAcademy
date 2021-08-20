namespace OperationsBetweenNumbers
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            char operation = char.Parse(Console.ReadLine());
            if (operation == '+')
            {
                int sum = a + b;
                string s = sum % 2 == 0 ? "even" : "odd";
                Console.WriteLine($"{a} + {b} = {sum} - {s}");
            }
            else if (operation == '-')
            {
                int sum = a - b;
                string s = sum % 2 == 0 ? "even" : "odd";
                Console.WriteLine($"{a} - {b} = {sum} - {s}");
            }
            else if (operation == '*')
            {
                int sum = a * b;
                string s = sum % 2 == 0 ? "even" : "odd";
                Console.WriteLine($"{a} * {b} = {sum} - {s}");
            }
            else if (operation == '/')
            {
                if (b != 0)
                {
                    double sum = a / (b * 1.0);
                    Console.WriteLine($"{a} / {b} = {sum:F2}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {a} by zero");
                }
            }
            else if (operation == '%')
            {
                if (b != 0)
                {
                    int sum = a % b;
                    Console.WriteLine($"{a} % {b} = {sum}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {a} by zero");
                }
            }
        }
    }
}
