namespace CharacterMultiplier
{
    using System;
    public class Multiplier
    {
        static void Main(string[] args)
        {
            string[] texts = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string first = texts[0];
            string second = texts[1];
            long sum = NewMethod(first, second);

            Console.WriteLine(sum);
        }

        private static long NewMethod(string first, string second)
        {
            long sum = 0;

            int minLength = first.Length < second.Length ? first.Length : second.Length;
            int maxLength = first.Length >= second.Length ? first.Length : second.Length;

            for (int i = 0; i < maxLength; i++)
            {
                if (i < minLength)
                {
                    sum += (first[i] * second[i]);
                }
                else
                {
                    if (first.Length == maxLength)
                    {
                        for (; i < maxLength; i++)
                        {
                            sum += first[i];
                        }

                        break;
                    }
                    else
                    {

                        for (; i < maxLength; i++)
                        {
                            sum += second[i];
                        }

                        break;
                    }
                }
            }

            return sum;
        }
    }
}