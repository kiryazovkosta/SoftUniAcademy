namespace Zoo
{
    using System;

    public class Animal
    {
        protected Animal(string name)
        {
            this.Name = name;
        }

        private string Name { get; set; }
    }
}
