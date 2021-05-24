namespace SpiceMustFlow
{
    using System;
    public class SpiceMustFlowMain
    {
        public static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());
            int days = 0;
            int totalSpices = 0;

            while (yield >= 100)
            {
                int spice = yield - 26;
                totalSpices += spice;

                days++;
                yield -= 10;
                if (yield < 100 )
                {
                    totalSpices -= 26;
                }  
            }

            Console.WriteLine(days);
            Console.WriteLine(totalSpices);
        }
    }
}
