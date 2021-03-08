namespace YardGreening
{
    using System;
    class StartUp
    {
        static void Main(string[] args)
        {
            double area = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

            double totalPrice = area * 7.61;
            double discount = totalPrice * 0.18;
            double finalPrice = totalPrice - discount;

            Console.WriteLine($"The final price is: {finalPrice} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");
        }
    }
}
