namespace ValidPerson
{
    using System;
    using System.Linq;

    public class Person : IPerson
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get => this.firstName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(
                        nameof(this.FirstName),
                        "The first name cannot be null or empty");
                }

                if (!ValidateSymbols(value))
                {
                    throw new InvalidPersonNameException($"The {value} contains invalid symbols for first name");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(
                        nameof(this.LastName),
                        $"The last name cannot be null or empty");
                }

                if (!ValidateSymbols(value))
                {
                    throw new InvalidPersonNameException($"The {value} contains invalid symbols for last name");
                }

                this.lastName = value;
            }
        }

        public int Age
        {
            get => this.age;
            set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(this.Age),
                        "Age should be in the range [0 .. 120].");
                }

                this.age = value;
            }
        }

        private bool ValidateSymbols(string value)
        {
            return value.All(c => char.IsLetter(c));
        }
    }
}
