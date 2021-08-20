using System;

namespace TriplesOfLatinLetters
{
    class TriplesOfLatinLettersMain
    {
        static void Main(string[] args)
        {
            char firstletter = 'a';
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < number; j++)
                {
                    for (int k = 0; k < number; k++)
                    {
                        char first = (char)(i + firstletter);
                        char middle = (char)(j + firstletter);
                        char last = (char)(k + firstletter);
                        Console.WriteLine($"{first}{middle}{last}");
                    }
                }
            }
        }
    }
}
