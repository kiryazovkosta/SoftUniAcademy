namespace INStock
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    public class Product : IComparable<Product>
    {
        public Product(string label, decimal price, int quantity)
        {
            Label = label;
            Price = price;
            Quantity = quantity;
        }

        public string Label { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public int CompareTo([AllowNull] Product other)
        {
            return this.Label.CompareTo(other.Label);
        }
    }
}
