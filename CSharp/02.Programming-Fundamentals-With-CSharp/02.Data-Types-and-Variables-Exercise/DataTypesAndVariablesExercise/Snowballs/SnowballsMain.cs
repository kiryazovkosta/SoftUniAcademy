namespace Snowballs
{
    using System;
    using System.Numerics;

    public class SnowballsMain
    {
        public static void Main(string[] args)
        {
            int highestSnowballSnow = 0;
            int highestSnowballTime = 0;
            int highestSnowballQuantity = 0;
            BigInteger highestSnowballValue = 0;

            int snowballsNumber = int.Parse(Console.ReadLine());
            for (int snowballIndex = 0; snowballIndex < snowballsNumber; snowballIndex++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuantity = int.Parse(Console.ReadLine());

                BigInteger snowballValue = BigInteger.Pow((snowballSnow / snowballTime), snowballQuantity);
                if (snowballValue > highestSnowballValue)
                {
                    highestSnowballSnow = snowballSnow;
                    highestSnowballTime = snowballTime;
                    highestSnowballQuantity = snowballQuantity;
                    highestSnowballValue = snowballValue;
                }
            }

            Console.WriteLine($"{highestSnowballSnow} : {highestSnowballTime} = {highestSnowballValue} ({highestSnowballQuantity})");
        }
    }
}
