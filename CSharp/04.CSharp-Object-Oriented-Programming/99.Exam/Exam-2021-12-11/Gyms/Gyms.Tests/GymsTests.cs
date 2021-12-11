using NUnit.Framework;
using System;

namespace Gyms.Tests
{
    [TestFixture]
    public class GymsTests
    {
        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void Ctor_ThrowException(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Gym(name, 10));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-5)]
        public void Ctor_ThrowException2(int size)
        {
            Assert.Throws<ArgumentException>(() => new Gym("Gym", size));
        }

        [Test]
        public void Ctor_CreateValidObject()
        {
            Gym gym = new Gym("Gym", 10);
            Assert.IsNotNull(gym);
            Assert.AreEqual("Gym", gym.Name);
            Assert.AreEqual(10, gym.Capacity);
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void AddAthlete_ThrowsException()
        {
            Gym gym = new Gym("Gym", 0);
            Athlete athlete = new Athlete("Nacepena Batka");
            Assert.Throws<InvalidOperationException>(() => gym.AddAthlete(athlete));
        }

        [Test]
        public void AddAthlete_SuccessfullyIsAdded()
        {
            Gym gym = new Gym("Gym", 5);
            Athlete athlete = new Athlete("Nacepena Batka");
            gym.AddAthlete(athlete);
            Assert.AreEqual(1, gym.Count);
        }

        [Test]
        public void RemoveAthlete_ThrowsException()
        {
            Gym gym = new Gym("Gym", 5);
            Athlete athlete = new Athlete("Nacepena Batka");
            gym.AddAthlete(athlete);
            Assert.Throws<InvalidOperationException>(() => gym.RemoveAthlete("Fantomas"));
        }

        [Test]
        public void RemoveAthlete_SuccessfullyIsRemoved()
        {
            Gym gym = new Gym("Gym", 5);
            Athlete athlete = new Athlete("Nacepena Batka");
            gym.AddAthlete(athlete);
            gym.RemoveAthlete("Nacepena Batka");
            Assert.AreEqual(0, gym.Count);
        }

        [Test]
        public void InjureAthlete_ThrowsException()
        {
            Gym gym = new Gym("Gym", 5);
            Athlete athlete = new Athlete("Nacepena Batka");
            gym.AddAthlete(athlete);
            Assert.Throws<InvalidOperationException>(() => gym.InjureAthlete("Fantomas"));
        }

        [Test]
        public void InjureAthlete_SuccessfullyIsInjured()
        {
            Gym gym = new Gym("Gym", 5);
            Athlete athlete = new Athlete("Nacepena Batka");
            gym.AddAthlete(athlete);
            var result = gym.InjureAthlete("Nacepena Batka");
            Assert.AreEqual(1, gym.Count);
            Assert.AreEqual(true, result.IsInjured);
            Assert.AreEqual("Nacepena Batka", result.FullName);
        }

        [Test]
        public void Report_SuccessfullyReported()
        {
            Gym gym = new Gym("Gym", 5);
            Athlete athlete = new Athlete("Nacepena Batka");
            string report = $"Active athletes at Gym: Nacepena Batka";
            gym.AddAthlete(athlete);
            var result = gym.Report();
            Assert.AreEqual(report, result);
        }


    }
}
