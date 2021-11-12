namespace EnterNumbers
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            int start = 0;
            int end = 90;

            int[] numbers = new int[10];
            for (int i = 0; i < numbers.Length; i++)
            {
                int number = ReadNumber(start, end);
                numbers[i] = number;
                start = number + 1;
                end++;
            }

            Console.WriteLine(string.Join(" ", numbers));
        }

        private static int ReadNumber(int start, int end)
        {
            do
            {
                try
                {
                    Console.Write($"Enter a number between {start} and {end}: ");
                    string input = Console.ReadLine() ?? string.Empty;
                    int number = int.Parse(input);
                    if (number < start || number > end)
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    return number;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Input cannot be null");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input string is not in valid format");
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Need to eenter a number between {start} and {end}");
                }

            } while (true);
        }
    }
}
