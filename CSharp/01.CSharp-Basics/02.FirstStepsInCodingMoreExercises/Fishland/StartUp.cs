namespace Fishland
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            double skumriaPerKilogram = double.Parse(Console.ReadLine());
            double cacaPerKilogram = double.Parse(Console.ReadLine());
            double palamudKilograms = double.Parse(Console.ReadLine());
            double safridKilograms = double.Parse(Console.ReadLine());
            int midiKilograms = int.Parse(Console.ReadLine());

            double palamudPerKilogram = skumriaPerKilogram + (skumriaPerKilogram * 0.60);
            double palamudPrice = palamudPerKilogram * palamudKilograms;
            double safridPerKilogram = cacaPerKilogram + (cacaPerKilogram * 0.80);
            double safridPrice = safridPerKilogram * safridKilograms;
            double midiPrice = midiKilograms * 7.50;

            double totalPrice = palamudPrice + safridPrice + midiPrice;
            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}
