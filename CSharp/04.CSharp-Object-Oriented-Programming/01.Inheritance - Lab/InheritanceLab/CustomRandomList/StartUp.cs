namespace CustomRandomList
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var colors = new List<string>()
            {
                "red", "green", "yellow", "brown", "black", "white", "pink"
            };

            var randomList = new RandomList
            {
                "blue"
            };
            randomList.AddRange(colors);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(randomList.RandomString());
            }
        }
    }
}
