namespace UnitTestingBasics.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class AxeTests
    {
        private const int AxeAttack = 5;
        private const int AxeDurabillity = 1;

        private const int DummyHealth = 10;
        private const int DummyExperience = 10;

        private const string AxeIsBrokenMessage = "Axe is broken.";

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void Setup()
        {
            axe = new Axe(AxeAttack, AxeDurabillity);
            dummy = new Dummy(DummyHealth, DummyExperience);
        }

        [Test]
        public void Attack_ShouldLooseDurabilityAfterEachAttack()
        {
            this.axe.Attack(dummy);
            Assert.That(this.axe.DurabilityPoints, Is.EqualTo(0));
        }

        [Test]
        public void Attack_ShouldThrowAnExceptionWhenAttackWithBrokenAxe()
        {
            axe.Attack(dummy);
            Assert.Throws<InvalidOperationException>(() => this.axe.Attack(dummy), AxeIsBrokenMessage);
        }
    }
}
