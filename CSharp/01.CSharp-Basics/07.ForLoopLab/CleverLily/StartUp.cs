namespace CleverLily
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double washingMachinePrice = double.Parse(Console.ReadLine());
            double toyPrice = double.Parse(Console.ReadLine());

            double sum = 0.0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    sum += (i * 5) - 1;
                }
                else
                {
                    sum += toyPrice;
                }
            }

            if (sum >= washingMachinePrice)
            {
                Console.WriteLine($"Yes! {sum-washingMachinePrice:F2}");
            }
            else
            {
                Console.WriteLine($"No! {washingMachinePrice-sum:F2}");
            }
        }
    }
}
