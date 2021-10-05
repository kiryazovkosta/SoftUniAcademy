namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Pokemon
    {
        private string name;
        private ElementType element;
        private int health;

        public Pokemon(string name, ElementType element, int health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }

        public string Name
        {
            get => this.name;
            private set => this.name = value;
        }

        public ElementType Element
        {
            get => this.element;
            private set => this.element = value;
        }

        public int Health
        {
            get => this.health;
            private set => this.health = value;
        }

        public void DecreaseHealth(int value)
        {
            this.Health -= value;
        }
    }
}
