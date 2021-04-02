namespace MaxNumber
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int max = Int32.MinValue;
            string input = Console.ReadLine();
            while (input != "Stop")
            {
                int number = int.Parse(input);
                if (number > max)
                {
                    max = number;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(max);
        }
    }
}
