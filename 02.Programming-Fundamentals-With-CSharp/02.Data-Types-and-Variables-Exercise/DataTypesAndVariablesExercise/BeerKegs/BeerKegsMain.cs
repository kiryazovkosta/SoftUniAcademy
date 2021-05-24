namespace BeerKegs
{
    using System;
    public class BeerKegsMain
    {
        public static void Main(string[] args)
        {
            double maxVolume = double.MinValue;
            string maxModel = string.Empty;

            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int height = int.Parse(Console.ReadLine());

                double volume = Math.PI * Math.Pow(radius, 2) * height;
                if (volume > maxVolume)
                {
                    maxVolume = volume;
                    maxModel = model;
                }
            }

            Console.WriteLine(maxModel);
        }
    }
}
