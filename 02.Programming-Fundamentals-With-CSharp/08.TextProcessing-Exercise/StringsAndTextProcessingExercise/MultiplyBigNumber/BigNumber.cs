namespace MultiplyBigNumber
{
    using System;
    using System.Text;

    public class BigNumber
    {
        static void Main(string[] args)
        {
            string number = Console.ReadLine().TrimStart('0');
            int digit = int.Parse(Console.ReadLine());
            StringBuilder result = new StringBuilder();
            if (digit == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                int remainder = 0;
                for (int i = number.Length - 1; i >= 0; i--)
                {
                    int currentDigit = int.Parse(number[i].ToString());
                    int currentProduct = (currentDigit * digit) + remainder;
                    int currentProductForAdding = currentProduct % 10;
                    result.Insert(0, currentProductForAdding);
                    remainder = currentProduct / 10;
                }

                if (remainder > 0)
                {
                    result.Insert(0, remainder);
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}
