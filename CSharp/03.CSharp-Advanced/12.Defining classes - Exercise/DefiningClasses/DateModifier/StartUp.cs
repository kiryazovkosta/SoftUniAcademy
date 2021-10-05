namespace DefiningClasses
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            string first = Console.ReadLine();
            string second = Console.ReadLine();
            int days = DateModifier.CalculateDifferenceInDays(first, second);
            Console.WriteLine(days);
        }
    }
}
