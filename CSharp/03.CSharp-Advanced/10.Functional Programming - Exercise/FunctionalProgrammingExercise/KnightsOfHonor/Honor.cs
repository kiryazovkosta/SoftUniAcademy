﻿namespace KnightsOfHonor
{
    using System;
    using System.Linq;

    public class Honor
    {
        static void Main(string[] args)
        {
            Action<string> print = name => Console.WriteLine($"Sir {name}");
            Console.ReadLine()?.Split(" ").ToList().ForEach(print);
        }
    }
}