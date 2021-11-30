namespace Tests
{
    using NUnit.Framework;

    using FightingArena;
    using System;

    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Hero", 1, 100)]
        [TestCase("Hero", 10, 0)]
        public void CtorCreateValidWarrior(
            string name,
            int damage,
            int hp)
        {
            Warrior warrior = new Warrior(name, damage, hp);
            Assert.IsNotNull(warrior);
        }

        [Test]
        [TestCase("", 10, 100, "Name should not be empty or whitespace!")]
        [TestCase(null, 10, 100, "Name should not be empty or whitespace!")]
        [TestCase("Hero", 0, 100, "Damage value should be positive!")]
        [TestCase("Hero", -5, 100, "Damage value should be positive!")]
        [TestCase("Hero", 10, -1, "HP should not be negative!")]
        public void CtorThrowExceptionOnInvalidInput(
            string name,
            int damage,
            int hp,
            string message)
        {
            var exception = Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
            Assert.AreEqual(message, exception.Message);
        }

        [Test]
        [TestCase("Hero", 10, 20)]
        [TestCase("Hero", 10, 30)]
        public void AttackShouldThrowExceptionWhenHPIsSmallerOrEqualToMinAttackHp(
            string name,
            int damage,
            int hp)
        {
            Warrior warrior = new Warrior("Warrior", 10, 60);
            Warrior current = new Warrior(name, damage, hp);
            var exception = Assert.Throws<InvalidOperationException>( () => current.Attack(warrior));
            Assert.AreEqual("Your HP is too low in order to attack other warriors!", exception.Message);
        }

        [Test]
        [TestCase("Hero", 10, 20)]
        [TestCase("Hero", 10, 30)]
        public void AttackShouldThrowExceptionWhenWarriorHPIsSmallerOrEqualToMinAttackHp(
            string name,
            int damage,
            int hp)
        {
            Warrior warrior = new Warrior(name, damage, hp); 
            Warrior current = new Warrior("Warrior", 10, 60);
            var exception = Assert.Throws<InvalidOperationException>(() => current.Attack(warrior));
            Assert.That(exception.Message, Contains.Substring("Enemy HP must be greater than "));
        }

        [Test]
        public void AttackShouldThrowExceptionWhenWarriorHPIsSmallerThanEnemyDamage()
        {
            Warrior warrior = new Warrior("Warrior", 120, 100);
            Warrior hero = new Warrior("Hero", 40, 100);
            var exception = Assert.Throws<InvalidOperationException>(() => hero.Attack(warrior));
            Assert.That(exception.Message, Contains.Substring("You are trying to attack too strong enemy"));
        }

        [Test]
        [TestCase("Hero", 80, 100, 69, 0)]
        [TestCase("Hero", 50, 51, 20, 0)]
        [TestCase("Hero", 40, 35, 4, 10)]
        [TestCase("Hero", 50, 35, 4, 0)]
        public void AttackShouldSuccessfullyComplete(
            string name,
            int damage,
            int hp,
            int heroHp,
            int warriorHp)
        {
            Warrior hero = new Warrior(name, damage, hp);
            Warrior warrior = new Warrior("Warrior", 31, 50);
            hero.Attack(warrior);
            Assert.AreEqual(heroHp, hero.HP);
            Assert.AreEqual(warriorHp, warrior.HP);
        }
    }
}