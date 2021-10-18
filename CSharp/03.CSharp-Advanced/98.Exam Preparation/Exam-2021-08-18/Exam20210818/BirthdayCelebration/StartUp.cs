namespace BirthdayCelebration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var guests = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            var plates = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));

            int wasted = 0;

            while (guests.Count > 0 && plates.Count > 0)
            {
                int plate = plates.Peek();
                int guest = guests.Peek();

                while (guest > 0 && plates.Count > 0)
                {
                    if (plate >= guest)
                    {
                        guests.Dequeue();
                        plates.Pop();
                        wasted += (plate - guest);
                        guest -= plate;
                    }
                    else
                    {
                        plates.Pop();
                        guest -= plate;
                        plate = plates.Peek();
                    }
                }
            }

            if (plates.Count > 0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }
            else if (guests.Count > 0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", guests)}");
            }

            Console.WriteLine($"Wasted grams of food: {wasted}");
        }
    }
}