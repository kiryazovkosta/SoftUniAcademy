﻿namespace CharacterSequence
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();
            for (int i = 0; i < text.Length; i++)
            {
                Console.WriteLine(text[i]);
            }
        }
    }
}
