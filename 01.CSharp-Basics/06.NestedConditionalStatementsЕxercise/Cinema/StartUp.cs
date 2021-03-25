namespace Cinema
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string projection = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            double profit = 0.0;
            if (projection == "Premiere")
            {
                profit = cols * rows * 12.0;
            }
            else if (projection == "Normal")
            {
                profit = cols * rows * 7.5;
            }
            else if (projection == "Discount")
            {
                profit = cols * rows * 5;
            }

            Console.WriteLine($"{profit:F2} leva");
        }
    }
}
