namespace MetricConverter
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            string input = Console.ReadLine();
            string output = Console.ReadLine();

            double inputNumber = 0;
            if (input == "mm")
            {
                inputNumber = number;
            }
            else if (input == "cm")
            {
                inputNumber = number * 10;
            }
            else
            {
                inputNumber = number * 1000;
            }

            double outputNumber = 0;
            if (output == "mm")
            {
                outputNumber = inputNumber;
            }
            else if (output == "cm")
            {
                outputNumber = inputNumber / 10;
            }
            else
            {
                outputNumber = inputNumber / 1000;
            }

            Console.WriteLine($"{outputNumber:F3}");
        }
    }
}
