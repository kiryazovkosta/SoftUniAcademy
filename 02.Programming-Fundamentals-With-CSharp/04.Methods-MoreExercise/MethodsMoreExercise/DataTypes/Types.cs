// ------------------------------------------------------------------------------------------------
//  <copyright file="Types.cs" company="Business Management System Ltd.">
//      Copyright "2021" (c), Business Management System Ltd.
//      All rights reserved.
//  </copyright>
//  <author>Kosta.Kiryazov</author>
// ------------------------------------------------------------------------------------------------

namespace DataTypes
{
    #region Using

    using System;

    #endregion

    internal class Types
    {
        private static void Main(string[] args)
        {
            string type = Console.ReadLine();
            switch (type)
            {
                case "int":
                    int integer = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(integer)));
                    Process(integer);
                    break;

                case "real":
                    double number = double.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(number)));
                    Process(number);
                    break;

                case "string":
                    Process(Console.ReadLine() ?? throw new ArgumentException());
                    break;

                default:
                    break;
            }
        }

        private static void Process(int number)
        {
            int result = number * 2;
            Console.WriteLine(result);
        }

        private static void Process(double number)
        {
            double result = number * 1.5;
            Console.WriteLine($"{result:F2}");
        }

        private static void Process(string text)
        {
            Console.WriteLine($"${text}$");
        }
    }
}