namespace Messaging
{
    #region Using

    using System;
    using System.Linq;

    #endregion

    public class Message
    {
        public static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();

            var message = Console.ReadLine() ?? string.Empty;
            foreach (var number in numbers)
            {
                var numberIndex = CalculateDigitsSum(number);
                var symbolIndex = GetCharIndexFromMessage(message, numberIndex);
                Console.Write(message[symbolIndex]);

                message = message.Remove(symbolIndex, 1);
            }
        }

        private static int GetCharIndexFromMessage(string message, int index)
        {
            var countIndex = 0;

            for (var i = 0; i < index; i++)
            {
                countIndex++;
                if (countIndex == message.Length)
                {
                    countIndex = 0;
                }
            }

            return countIndex;
        }

        private static int CalculateDigitsSum(int number)
        {
            var sum = 0;
            while (number > 0)
            {
                var digit = number % 10;
                number /= 10;
                sum += digit;
            }

            return sum;
        }
    }
}