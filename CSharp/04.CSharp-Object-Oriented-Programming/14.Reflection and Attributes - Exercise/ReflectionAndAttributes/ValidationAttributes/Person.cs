namespace ValidationAttributes
{
    using System;
    public class Person
    {
        private string fullName;
        private int age;

        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        [MyRequired]
        public string FullName 
        { 
            get => this.fullName; 
            set => this.fullName = value; 
        }

        [MyRange(12, 90)]
        public int Age 
        { 
            get => this.age; 
            set => this.age = value; 
        }
    }
}
