using System;

namespace OscarsCeremony
{
    class Program
    {
        static void Main(string[] args)
        {
            int rent = int.Parse(Console.ReadLine());
            double statuetki = rent - rent * 0.3;
            double ketaring = statuetki - (statuetki * 0.15);
            double sound = ketaring / 2;
            double razhodi = rent + statuetki + ketaring + sound;
            Console.WriteLine($"{razhodi:F2}");

        }
    }
}
