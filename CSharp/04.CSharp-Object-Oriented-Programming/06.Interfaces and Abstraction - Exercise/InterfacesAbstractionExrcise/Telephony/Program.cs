using System;

namespace Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            var smartphone = new Smartphone();
            var numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var number in numbers)
            {
                Console.WriteLine(smartphone.MakeCall(number));
            }

            var sites = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var site in sites)
            {
                Console.WriteLine(smartphone.Browsing(site));
            }
        }
    }
}
