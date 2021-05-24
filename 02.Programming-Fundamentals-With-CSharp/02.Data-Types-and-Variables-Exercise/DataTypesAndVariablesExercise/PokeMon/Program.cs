namespace PokeMon
{
    using System;
    public class Program
    {
        public static void Main()
        {
            int pokePower = int.Parse(Console.ReadLine() 
                ?? throw new InvalidOperationException());
            int pokeDistance = int.Parse(Console.ReadLine() 
                ?? throw new InvalidOperationException());
            int pokeExhaustionFactor = int.Parse(Console.ReadLine() 
                ?? throw new InvalidOperationException());

            int targetCount = 0;
            decimal halfPower = pokePower * 0.5m;

            while (pokePower >= pokeDistance)
            {
                targetCount++;
                pokePower -= pokeDistance;

                if (pokePower == halfPower && pokeExhaustionFactor > 0)
                {
                    pokePower /= pokeExhaustionFactor;
                }
            }

            Console.WriteLine(pokePower);
            Console.WriteLine(targetCount);
        }
    }
}
