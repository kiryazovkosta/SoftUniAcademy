namespace FlowerWreaths
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> lilies = new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> roses = new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse));

            int wreaths = 0;
            int flowers = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                int lile = lilies.Pop();
                int rose = roses.Dequeue();

                int sum = lile + rose;
                if (sum == 15)
                {
                    wreaths++;
                }
                else if (sum < 15)
                {
                    flowers += sum;
                }
                else
                {
                    if (sum % 2 == 0)
                    {
                        flowers += 14;
                    }
                    else
                    {
                        wreaths++;
                    }
                }
            }

            wreaths += (flowers / 15);
            Console.WriteLine(wreaths >= 5
                ? $"You made it, you are going to the competition with {wreaths} wreaths!"
                : $"You didn't make it, you need {5 - wreaths} wreaths more!");
        }
    }
}