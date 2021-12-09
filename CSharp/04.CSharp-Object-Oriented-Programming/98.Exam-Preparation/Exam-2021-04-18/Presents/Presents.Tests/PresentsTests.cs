namespace Presents.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;

        [SetUp]
        public void Setup()
        {
            bag = new Bag();
        }

        [Test]
        public void Ctor_CreateValidObject()
        {
            Assert.IsNotNull(bag);
            Assert.IsNotNull(bag.GetPresents());
            Assert.AreEqual(0, bag.GetPresents().Count);
        }

        [Test]
        public void CreateShouldThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => bag.Create(null));
        }

        [Test]
        public void CreateShouldThrowsException2()
        {
            Present present = new Present("Present", 20.0);
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }


        [Test]
        public void CreateShouldReturnValidOutput()
        {
            Present present = new Present("Present", 20.0);
            var result = bag.Create(present);
            Assert.AreEqual($"Successfully added present {present.Name}.", result);
        }

        [Test]
        public void RemoveShouldReturnValid()
        {
            Present present = new Present("Present", 20.0);
            bag.Create(present);
            var resultTrue = bag.Remove(present);
            var resultFalse = bag.Remove(present);
            Assert.AreEqual(true, resultTrue);
            Assert.AreEqual(false, resultFalse);
        }

        [Test]
        public void GetPresentWithLeastMagicShouldReturnValid()
        {
            Present present1 = new Present("Present1", 20.0);
            Present present2 = new Present("Present2", 10.0);
            Present present3 = new Present("Present3", 30.0);
            bag.Create(present1);
            bag.Create(present2);
            bag.Create(present3);

            var result = bag.GetPresentWithLeastMagic();
            Assert.AreSame(result, present2);
        }

        [Test]
        public void GetPresentShouldReturnValid1()
        {
            Present present1 = new Present("Present1", 20.0);
            Present present2 = new Present("Present2", 10.0);
            Present present3 = new Present("Present3", 30.0);
            bag.Create(present1);
            bag.Create(present2);
            bag.Create(present3);

            var result = bag.GetPresent("Present1");
            Assert.AreSame(result, present1);
        }


        [Test]
        public void GetPresentShouldReturnValid2()
        {
            Present present1 = new Present("Present1", 20.0);
            Present present2 = new Present("Present2", 10.0);
            Present present3 = new Present("Present3", 30.0);
            bag.Create(present1);
            bag.Create(present2);
            bag.Create(present3);

            var result = bag.GetPresent("Present4");
            Assert.AreSame(result, null);
        }


    }
}
