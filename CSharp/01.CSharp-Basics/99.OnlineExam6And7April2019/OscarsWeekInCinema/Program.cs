using System;

namespace OscarsWeekInCinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string type = Console.ReadLine();
            int tickets = int.Parse(Console.ReadLine());
            double price = 0.0;
            switch (name)
            {
                case "A Star Is Born":
                    switch (type)
                    {
                        case "normal":
                            price = 7.5;
                            break;
                        case "luxury":
                            price = 10.5;
                            break;
                        case "ultra luxury":
                            price = 13.5;
                            break;

                        default:
                            break;
                    }
                    break;
                case "Bohemian Rhapsody":
                    switch (type)
                    {
                        case "normal":
                            price = 7.35;
                            break;
                        case "luxury":
                            price = 9.45;
                            break;
                        case "ultra luxury":
                            price = 12.75;
                            break;

                        default:
                            break;
                    }
                    break;
                case "Green Book":
                    switch (type)
                    {
                        case "normal":
                            price = 8.15;
                            break;
                        case "luxury":
                            price = 10.25;
                            break;
                        case "ultra luxury":
                            price = 13.25;
                            break;

                        default:
                            break;
                    }
                    break;
                case "The Favourite":
                    switch (type)
                    {
                        case "normal":
                            price = 8.75;
                            break;
                        case "luxury":
                            price = 11.55;
                            break;
                        case "ultra luxury":
                            price = 13.95;
                            break;

                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            if (price > 0)
            {
                Console.WriteLine($"{name} -> {tickets*price:F2} lv.");
            }

        }
    }
}
