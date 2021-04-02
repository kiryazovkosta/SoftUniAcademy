namespace Moving
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());
            int size = a * b * h;
            string input = Console.ReadLine();
            while (input != "Done")
            {
                int boxes = int.Parse(input);
                size -= boxes;
                if (size < 0)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            if (size >= 0)
            {
                Console.WriteLine($"{size} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {Math.Abs(size)} Cubic meters more.");
            }
        }
    }
}
