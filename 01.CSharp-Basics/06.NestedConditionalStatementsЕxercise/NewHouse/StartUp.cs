namespace NewHouse
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string flowersType = Console.ReadLine();
            int flowersNumber = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double price = 0.0;
            switch (flowersType)
            {
                case "Roses":
                    price = flowersNumber * 5;
                    if (flowersNumber > 80)
                    {
                        price = price - (price * 0.1);
                    }
                    break;

                case "Dahlias":
                    price = flowersNumber * 3.8;
                    if (flowersNumber > 90)
                    {
                        price = price - (price * 0.15);
                    }
                    break;

                case "Tulips":
                    price = flowersNumber * 2.8;
                    if (flowersNumber > 80)
                    {
                        price = price - (price * 0.15);
                    }
                    break;

                case "Narcissus":
                    price = flowersNumber * 3;
                    if (flowersNumber < 120)
                    {
                        price += (price * 0.15);
                    }
                    break;

                case "Gladiolus":
                    price = flowersNumber * 2.5;
                    if (flowersNumber < 80)
                    {
                        price += (price * 0.2);
                    }
                    break;

                default:
                    break;
            }

            if (budget >= price)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowersNumber} {flowersType} and {budget-price:F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {price - budget:F2} leva more.");
            }
        }
    }
}
