namespace Task02
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int food = int.Parse(Console.ReadLine());
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            double aFood = a * days;
            double bFood = b * days;
            double cFood = c * days;
            double total = aFood + bFood + cFood;
            if (food >= total)
            {
                Console.WriteLine($"{Math.Floor(food-total)} kilos of food left.");
            }
            else
            {
                Console.WriteLine($"{Math.Ceiling(total-food)} more kilos of food are needed.");
            }
        }
    }
}
