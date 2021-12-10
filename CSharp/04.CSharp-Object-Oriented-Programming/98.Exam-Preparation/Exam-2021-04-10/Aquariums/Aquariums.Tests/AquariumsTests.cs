namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AquariumsTests
    {

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Ctor_ThrowsExceptionWhenTryToCreateWithInvalidName(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Aquarium(name, 5));
        }

        [Test]
        [TestCase(-1)]
        public void Ctor_ThrowsExceptionWhenTryToCreateWithInvalidCapacity(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new Aquarium("Name", capacity));
        }

        [Test]
        public void Ctor_CreateValidObject()
        {
            Aquarium aquarium = new Aquarium("Name", 5);
            Assert.IsNotNull(aquarium);
            Assert.AreEqual(0, aquarium.Count);
            Assert.AreEqual("Name", aquarium.Name);
            Assert.AreEqual(5, aquarium.Capacity);
        }

        [Test]
        public void Add_ThrowsException()
        {
            Aquarium aquarium = new Aquarium("Name", 0);
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(new Fish("Pepi")));
        }

        [Test]
        public void Add_SuccessfullyAdded()
        {
            Aquarium aquarium = new Aquarium("Name", 5);
            Fish fish = new Fish("Nemo");
            aquarium.Add(fish);
            Assert.AreEqual(1, aquarium.Count);
        }

        [Test]
        public void RemoveFish_ThrowsException()
        {
            Aquarium aquarium = new Aquarium("Name", 5);
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Nemo"));
        }

        [Test]
        public void RemoveFish_SuccessfullyRemoveFish()
        {
            Aquarium aquarium = new Aquarium("Name", 5);
            Fish fish = new Fish("Nemo");
            aquarium.Add(fish);
            aquarium.RemoveFish("Nemo");
            Assert.AreEqual(0, aquarium.Count);
        }

        [Test]
        public void SellFish_ThrowsException()
        {
            Aquarium aquarium = new Aquarium("Name", 5);
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Nemo"));
        }

        [Test]
        public void SellFish_SuccessfullySellFish()
        {
            Aquarium aquarium = new Aquarium("Name", 5);
            Fish fish = new Fish("Nemo");
            aquarium.Add(fish);
            var sellFish = aquarium.SellFish("Nemo");
            Assert.AreEqual(false, sellFish.Available);
        }

        [Test]
        public void Report_SuccessfullyReported()
        {
            Aquarium aquarium = new Aquarium("Name", 5);
            Fish fish1 = new Fish("Nemo1");
            Fish fish2 = new Fish("Nemo2");
            aquarium.Add(fish1);
            aquarium.Add(fish2);
            var report = aquarium.Report();
            Assert.AreEqual("Fish available at Name: Nemo1, Nemo2", report);
        }
    }
}
