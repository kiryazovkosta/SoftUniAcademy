namespace StoreBoxes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Box
    {
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal PriceBox { get; set; }

        public Box()
        {
            this.Item = new Item();
        }
    }

    public class Boxes
    {
        static void Main(string[] args)
        {
            var boxes = ReadBoxes().OrderByDescending(b => b.PriceBox);
            PrintBoxes(boxes);
        }

        private static IEnumerable<Box> ReadBoxes()
        {
            var boxes = new List<Box>();
            var input = Console.ReadLine() ?? throw new ArgumentNullException();
            while (input != "end")
            {
                var data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var serialNumber = data[0];
                var itemName = data[1];
                var itemQuantity = int.Parse(data[2]);
                var itemPrice = decimal.Parse(data[3]);
                var boxPrice = itemQuantity * itemPrice;
                boxes.Add(new Box()
                {
                    SerialNumber = serialNumber,
                    Item = new Item() { Name = itemName, Price = itemPrice },
                    ItemQuantity = itemQuantity,
                    PriceBox = boxPrice
                });

                input = Console.ReadLine() ?? throw new ArgumentNullException();
            }

            return boxes;
        }

        private static void PrintBoxes(IEnumerable<Box> boxes)
        {
            foreach (var box in boxes)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:F2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceBox:F2}");
            }
        }
    }
}
