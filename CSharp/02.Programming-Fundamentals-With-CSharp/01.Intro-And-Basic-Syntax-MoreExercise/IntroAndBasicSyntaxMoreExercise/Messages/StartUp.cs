using System;

namespace Messages
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int clicks = int.Parse(Console.ReadLine() ?? throw new ArgumentException(nameof(clicks)));
            string message = String.Empty;
            for (int i = 0; i < clicks; i++)
            {
                string number = Console.ReadLine();
                int length = number.Length;
                int mainDigit = int.Parse(number[0].ToString());
                if (mainDigit == 0)
                {
                    message += ' ';
                    continue;
                }

                int offset = (mainDigit - 2) * 3;
                if (mainDigit == 8 || mainDigit == 9)
                {
                    offset++;
                }

                int index = (offset + length - 1);
                message += (char)(index + 97);
            }

            Console.WriteLine(message);
        }
    }
}
