﻿namespace DigitsLettersOther
{
    using System;
    using System.Collections.Generic;

    class Dlo
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            List<char> digits = new List<char>();
            List<char> letters = new List<char>();
            List<char> others = new List<char>();

            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsDigit(text[i]))
                {
                    digits.Add(text[i]);
                }
                else if (char.IsLetter(text[i]))
                {
                    letters.Add(text[i]);
                }
                else
                {
                    others.Add(text[i]);
                }
            }

            Console.WriteLine(string.Join("", digits));
            Console.WriteLine(string.Join("", letters));
            Console.WriteLine(string.Join("", others));
        }
    }
}