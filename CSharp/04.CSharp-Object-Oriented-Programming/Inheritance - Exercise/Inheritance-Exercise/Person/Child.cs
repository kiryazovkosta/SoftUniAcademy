namespace Person
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class Child : Person
    {
        public Child(string name, int age)
            : base(name, age)
        {
            if (this.Age > 15)
            {
                throw new ArgumentException(nameof(this.Age));
            }
        }

    }
}
