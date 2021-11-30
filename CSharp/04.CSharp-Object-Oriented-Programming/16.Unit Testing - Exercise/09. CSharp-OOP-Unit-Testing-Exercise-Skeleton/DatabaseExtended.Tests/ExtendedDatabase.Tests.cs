namespace Tests
{
    using NUnit.Framework;
    using System;

    using Extended;

    public class ExtendedDatabaseTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(16)]
        public void CtorShouldCreateValidExtendedDatabase(int length)
        {
            var database = SetupExtendedDatabase(length);
            Assert.That(database.Count, Is.EqualTo(length));
        }

        [Test]
        [TestCase(17)]
        [TestCase(25)]
        public void CtorShouldThrowExceptionWhenPersonsCountIsBiggerThenSixteen(int length)
        {
            var persons = new Person[length];
            var exception = Assert.Throws<ArgumentException>(() => new ExtendedDatabase(persons));
            Assert.That("Provided data length should be in range [0..16]!", Is.EqualTo(exception.Message));
        }

        [Test]
        [TestCase(0, 1)]
        [TestCase(5, 6)]
        [TestCase(15, 16)]
        public void AddShoudlAddUniquePersonToDatabaseWhenCountIsLessThanSixteen(
            int length,
            int expected)
        {
            var database = SetupExtendedDatabase(length);
            database.Add(new Person(20, "TestName"));

            Assert.AreEqual(expected, database.Count);
        }

        [Test]
        public void AddShouldThrowInvalidOperationExceptionWhenDatabaseLengthIsEqualToSixteen()
        {
            var database = SetupExtendedDatabase(16);
            var person = new Person(123, "TestUser");

            var exception = Assert.Throws<InvalidOperationException>( () => database.Add(person));
            Assert.That("Array's capacity must be exactly 16 integers!", Is.EqualTo(exception.Message));
        }

        [Test]
        [TestCase(10, 8, "TestUser", "There is already user with this Id!")]
        [TestCase(10, 12, "Name8", "There is already user with this username!")]
        public void AddShouldThrowInvalidOperationExceptionWhenPersoIsNotUnique(
            int length, int id, string name, string message)
        {
            var database = SetupExtendedDatabase(length);
            var person = new Person(id, name);

            var exception = Assert.Throws<InvalidOperationException>(() => database.Add(person));
            Assert.That(message, Is.EqualTo(exception.Message));
        }

        [Test]
        [TestCase(1, 0)]
        [TestCase(10, 9)]
        [TestCase(16, 15)]
        public void RemoveShouldRemoveLastPersonFromDatabase(int length, int expected)
        {
            var database = SetupExtendedDatabase(length);
            database.Remove();
            Assert.AreEqual(expected, database.Count);
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenDatabaseIsEmpty()
        {
            var database = SetupExtendedDatabase(0);
            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FindByUsernameReturnsValidPerson()
        {
            var exprectedPerson = new Person(4, "Name4");
            var database = SetupExtendedDatabase(6);
            var person = database.FindByUsername("Name4");
            Assert.That(exprectedPerson.Id, Is.EqualTo(person.Id));
            Assert.That(exprectedPerson.UserName, Is.EqualTo(person.UserName));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsernameShouldThrowExceptionWhenUsernameIsNullOrEmpty(string userName)
        {
            var database = SetupExtendedDatabase(6);
            var exception = Assert.Throws<ArgumentNullException>(() => database.FindByUsername(userName));
            Assert.That("Value cannot be null. (Parameter 'Username parameter is null!')", Is.EqualTo(exception.Message));
        }

        [Test]
        [TestCase("User7")]
        [TestCase("user3")]
        public void FindByUsernameShouldThrowExceptionWhenUsernameDoesNotExists(string userName)
        {
            var database = SetupExtendedDatabase(6);
            var exception = Assert.Throws<InvalidOperationException>(() => database.FindByUsername(userName));
            Assert.That("No user is present by this username!", Is.EqualTo(exception.Message));
        }


        [Test]
        public void FindByIdReturnsValidPerson()
        {
            var exprectedPerson = new Person(4, "Name4");
            var database = SetupExtendedDatabase(6);
            var person = database.FindById(4);
            Assert.That(exprectedPerson.Id, Is.EqualTo(person.Id));
            Assert.That(exprectedPerson.UserName, Is.EqualTo(person.UserName));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-5)]
        public void FindByIdShouldThrowExceptionWhenIdIsNegative(int id)
        {
            var database = SetupExtendedDatabase(6);
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => database.FindById(id));
            Assert.That(exception.Message, Contains.Substring("Id should be a positive number!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(7)]
        public void FindByIdShouldThrowExceptionWhenPersonWithIdDoesNotExists(int id)
        {
            var database = SetupExtendedDatabase(6);
            var exception = Assert.Throws<InvalidOperationException>(() => database.FindById(id));
            Assert.That("No user is present by this ID!", Is.EqualTo(exception.Message));
        }


        private static ExtendedDatabase SetupExtendedDatabase(int length)
        {
            var persons = new Person[length];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i + 1, $"Name{i + 1}");
            }
            var database = new ExtendedDatabase(persons);
            return database;
        }


    }
}