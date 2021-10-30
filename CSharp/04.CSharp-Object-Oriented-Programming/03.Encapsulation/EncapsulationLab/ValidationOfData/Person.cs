using System;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }

        public string FirstName
        {
            get => this.firstName;
            private set
            {
                ValidateName(value, "First name");
                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            private set
            {
                ValidateName(value, "Last name");
                this.lastName = value;
            }
        }

        public int Age
        {
            get => this.age;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }

                this.age = value;
            }
        }

        public decimal Salary
        {
            get => this.salary;
            private set
            {
                if (value < 650)
                {
                    throw new ArgumentException("Salary cannot be less than 650 leva!");
                }

                this.salary = value;
            }
        }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age > 30)
            {
                this.Salary += (this.Salary * (percentage / 100));
            }
            else
            {
                this.Salary += (this.Salary * ((percentage / 100) / 2));
            }
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
        }

        private bool ValidateName(string value, string parameter)
        {
            if (value.Length < 3)
            {
                throw new ArgumentException($"{parameter} cannot contain fewer than 3 symbols!");
            }

            return true;
        }
    }
}