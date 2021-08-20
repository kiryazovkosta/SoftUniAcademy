namespace MathPower
{
    #region Using

    using System;

    #endregion

    public class Power
    {
        internal static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(number)));
            int pow = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(pow)));

            double result = Pow(number, pow);
            Console.WriteLine(result);
        }

        private static double Pow(double number, int pow)
        {
            double result = number;
            for (var i = 1; i < pow; i++)
            {
                result *= number;
            }

            return result;
        }
    }
}