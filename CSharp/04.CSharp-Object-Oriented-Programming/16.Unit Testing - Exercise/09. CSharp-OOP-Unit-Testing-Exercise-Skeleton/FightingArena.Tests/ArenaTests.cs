namespace Tests
{
    using NUnit.Framework;

    using FightingArena;
    using System.Collections.Generic;
    using System;

    public class ArenaTests
    {
        private Arena arena;
        private Warrior first;
        private Warrior second;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
            first = new Warrior("Warrior", 30, 100);
            arena.Enroll(first);
            second = new Warrior("Hero", 50, 90);
            arena.Enroll(second);
        }

        [Test]
        public void CtorReturnsValidArena()
        {
            Assert.IsNotNull(arena);
            Assert.That(arena.Count, Is.EqualTo(2));
            Assert.AreEqual(arena.Warriors, new List<Warrior>() { first, second });
        }

        [Test]
        public void EnrollShouldEnrollWarriorToTheArena()
        {
            var hero = new Warrior("Vinetu", 25, 100);
            arena.Enroll(hero);
            Assert.That(arena.Count, Is.EqualTo(3));
        }

        [Test]
        public void EnrollShouldThrowExceptionWhenWarriorWithSameNameIsAlreadyEnroledToTHeArena()
        {
            var hero = new Warrior("Warrior", 25, 100);
            var exception = Assert.Throws<InvalidOperationException>( () =>arena.Enroll(hero));
            Assert.That(exception.Message, Contains.Substring("Warrior is already enrolled for the fights!"));
        }

        [Test]
        [TestCase("Wizard", "Hero", "Wizard")]
        [TestCase("Warrior", "Pinko", "Pinko")]
        [TestCase("Wizard", "Pinko", "Pinko")]
        public void FightShouldThrowExceptionWhenWarriorByNameMissingAtArena(
            string attacker,
            string defender,
            string missing)
        {
            var message = $"There is no fighter with name {missing} enrolled for the fights!";
            var exception = Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker, defender));
            Assert.That(exception.Message, Contains.Substring(message));
        }

        [Test]
        [TestCase("Warrior", "Hero")]
        public void FightShouldFight(
            string attacker,
            string defender)
        {
            arena.Fight(attacker, defender);

            Assert.AreEqual(50, first.HP);
            Assert.AreEqual(60, second.HP);
        }
    }
}
