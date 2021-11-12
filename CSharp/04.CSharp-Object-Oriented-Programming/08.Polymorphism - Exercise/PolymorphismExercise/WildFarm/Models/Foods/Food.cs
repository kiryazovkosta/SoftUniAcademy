namespace WildFarm.Models.Foods
{
    using System;

    public abstract class Food
    {
        private int quantity;

        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }

        public int Quantity
        {
            get => this.quantity;
            private set => this.quantity = value;
        }
    }
}