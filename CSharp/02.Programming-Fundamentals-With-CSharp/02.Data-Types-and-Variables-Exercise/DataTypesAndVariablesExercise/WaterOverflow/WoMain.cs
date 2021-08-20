namespace WaterOverflow
{
    using System;
    public class WoMain
    {
        public static void Main(string[] args)
        {
            double pourVolume = 0;
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                int quantity = int.Parse(Console.ReadLine());
                if (quantity + pourVolume > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                }
                else
                {
                    pourVolume += quantity;
                }
            }

            Console.WriteLine(pourVolume);
        }
    }
}
