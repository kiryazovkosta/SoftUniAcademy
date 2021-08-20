namespace WeddingSeats
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            char sectors = char.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());
            int seats = int.Parse(Console.ReadLine());
            int c = 0;
            for (int s = 'A'; s <= sectors; s++)
            {
                for (int i = 1; i <= rows; i++)
                {
                    int seatCount = i % 2 != 0 ? seats : seats + 2;
                    for (int j = 97; j < 97 + seatCount; j++)
                    {
                        Console.WriteLine($"{(char)s}{i}{(char)j}");
                        c++;
                    }
                }

                rows++;
            }

            Console.WriteLine(c);
        }
    }
}
