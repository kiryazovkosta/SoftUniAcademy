using System;

namespace Scholarship
{
    using System.ComponentModel.Design;

    class StartUp
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double success = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            double salary = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            double social = -1.0;
            double results = -1.0;

            if (income < salary && success > 4.5)
            {
                social = salary * 0.35;
            }

            if (success >= 5.5)
            {
                results = success * 25;
            }

            if (social == -1.0 && results == -1.0)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else
            {
                if (social > results)
                {
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(social)} BGN");
                }
                else
                {
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(results)} BGN");
                }
            }
        }
    }
}
