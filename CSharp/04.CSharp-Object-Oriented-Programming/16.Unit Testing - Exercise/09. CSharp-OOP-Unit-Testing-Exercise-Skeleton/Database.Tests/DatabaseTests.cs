namespace Tests
{
    using NUnit.Framework;
    using System;
    using System.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(1, 0)]
        [TestCase(1, 1)]
        [TestCase(1, 16)]
        public void CtorShouldCreateValidDatabaseWhenLengthOfArgumentsIsLestOtEqualsToSixteen(
            int start,
            int count)
        {
            var elements = Enumerable.Range(start, count).ToArray();
            var database = new Database.Database(elements);
            Assert.That(database.Count, Is.EqualTo(elements.Length));
        }

        [Test]
        public void AddShouldThrowsExceptionWhenDatabaseCountIsBiggerThenSixteen()
        {
            var database = new Database.Database(Enumerable.Range(1, 16).ToArray());
            var exception = Assert.Throws<InvalidOperationException>(() => database.Add(17));
            Assert.AreEqual("Array's capacity must be exactly 16 integers!", exception.Message);
        }

        [Test]
        public void AddShouldSuccessfullyInsertElement()
        {
            var database = new Database.Database();
            database.Add(5);
            Assert.AreEqual(1, database.Count);
        }

        [Test]
        [TestCase(1, 1, 0)]
        [TestCase(1, 10, 9)]
        [TestCase(1, 16, 15)]
        public void RemoveShouldRemoveLastElementFromDatabase(int start, int count, int expected)
        {
            var elements = Enumerable.Range(start, count).ToArray();
            var database = new Database.Database(elements);
            database.Remove();
            Assert.That(database.Count, Is.EqualTo(expected));
        }

        [Test]
        public void RemoveShouldThrowsExceptionWhenDatabaseIsEmpty()
        {
            var database = new Database.Database(Enumerable.Range(0, 0).ToArray());
            var exception = Assert.Throws<InvalidOperationException>(() => database.Remove());
            Assert.AreEqual("The collection is empty!", exception.Message);
        }

        [Test]
        public void FetchShouldReturnAllValidElements()
        {
            // Arange
            int[] expected = new int[] { 1, 2 };
            var database = new Database.Database(1, 2, 3);
            
            // Act
            database.Add(4);
            database.Add(5);
            database.Remove();
            database.Remove();
            database.Remove();
            int[] fetched = database.Fetch();

            // Assert
            Assert.AreEqual(expected, fetched);
        }
    }
}