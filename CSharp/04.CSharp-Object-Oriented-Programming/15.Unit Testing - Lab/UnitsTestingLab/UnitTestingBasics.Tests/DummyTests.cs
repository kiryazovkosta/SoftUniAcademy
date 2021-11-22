namespace UnitTestingBasics.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DummyTests
    {
        private const int AxeAttack = 5;
        private const int AxeDurabillity = 2;

        private const int DummyHealth = 10;
        private const int DummyExperience = 10;
        private const int DeadDummyHealth = -1;

        private const string DummyIsDeadMessage = "Dummy is dead.";
        private const string DummyIsNotDeadmessage = "Target is not dead.";

        private Axe axe;
        private Dummy dummy;
        private Dummy deadDummy;

        [SetUp]
        public void Setup()
        {
            axe = new Axe(AxeAttack, AxeDurabillity);
            dummy = new Dummy(DummyHealth, DummyExperience);
            deadDummy = new Dummy(DeadDummyHealth, DummyExperience);
        }

        [Test]
        public void TakeAttack_ShouldLosesHealthIfIsAttacked()
        {
            this.dummy.TakeAttack(this.axe.AttackPoints);
            Assert.That(this.dummy.Health, Is.EqualTo(5));
        }

        [Test]
        public void TakeAttack_ShouldThrowsExceptionWhenDeadDummyIsAttacked()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => this.deadDummy.TakeAttack(this.axe.AttackPoints));
            Assert.That(ex.Message, Is.EqualTo(DummyIsDeadMessage));
        }

        [Test]
        public void GiveExperience_DeadDummyCanGiveExperience()
        {
            int xp = this.deadDummy.GiveExperience();
            Assert.That(xp, Is.EqualTo(10));
        }

        [Test]
        public void GiveExperience_AliveDummyCannotGiveAnExperience()
        {
            var exception = Assert.Throws<InvalidOperationException>( () => this.dummy.GiveExperience());
            Assert.That(exception.Message, Is.EqualTo(DummyIsNotDeadmessage));
        }


    }
}
