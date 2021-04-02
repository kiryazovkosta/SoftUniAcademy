namespace Dishwasher
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int cyrcle = 1;
            int dishes = 0;
            int pots = 0;
            int washer = int.Parse(Console.ReadLine()) * 750;
            string input = Console.ReadLine();
            while (input != "End")
            {
                int number = int.Parse(input);
                if (cyrcle % 3 == 0)
                {
                    washer -= (number * 15);
                    pots += number;
                }
                else
                {
                    washer -= (number * 5);
                    dishes += number;
                }

                if (washer < 0)
                {
                    break;
                }

                input = Console.ReadLine();
                cyrcle++;
            }

            if (washer >= 0)
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{dishes} dishes and {pots} pots were washed.");
                Console.WriteLine($"Leftover detergent {washer} ml.");

            }
            else
            {
                Console.WriteLine($"Not enough detergent, {Math.Abs(washer)} ml. more necessary!");
            }
        }
    }
}
