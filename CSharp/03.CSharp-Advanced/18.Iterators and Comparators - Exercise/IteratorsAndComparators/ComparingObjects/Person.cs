namespace ComparingObjects
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    public class Person : IComparable<Person>
    {
        private string name;
        private int age;
        private string town;

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public int Age
        {
            get => this.age;
            set => this.age = value;
        }

        public string Town
        {
            get => this.town;
            set => this.town = value;
        }

        public int CompareTo([AllowNull] Person other)
        {
            int compare = String.Compare(this.Name, other.Name, StringComparison.Ordinal);
            if (compare != 0)
            {
                return compare;
            }

            compare = this.Age.CompareTo(other.Age);
            if (compare != 0)
            {
                return compare;
            }

            compare = String.Compare(this.Town, other.Town, StringComparison.Ordinal);
            return compare;
        }
    }
}
