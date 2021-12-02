namespace INStock.Tests
{
    using NUnit.Framework;

    using INStock;

    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void Ctor_CreateValidproduct()
        {
            Product product = new Product("Label", 12.5M, 100);
            Assert.IsNotNull(product);
            Assert.AreEqual("Label", product.Label);
            Assert.AreEqual(12.5M, product.Price);
            Assert.AreEqual(100, product.Quantity); 
        }

        [Test]
        [TestCase("A", "B", 10, 10, -1)]
        [TestCase("A", "A", 10, 10, 0)]
        [TestCase("B", "A", 10, 10, 1)]
        public void CompareToReturnsValidValues(
            string firstLabel, 
            string secondLabel,
            decimal price,
            int quantity,
            int expected)
        {
            Product first = new Product(firstLabel, price, quantity);
            Product second = new Product(secondLabel, price, quantity);

            int compare = first.CompareTo(second);
            Assert.AreEqual(expected, compare);
        }
    }
}