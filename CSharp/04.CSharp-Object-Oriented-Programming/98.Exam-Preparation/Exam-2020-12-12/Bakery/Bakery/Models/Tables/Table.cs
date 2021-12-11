using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private readonly List<IBakedFood> foodOrders;
        private readonly List<IDrink> drinkOrders;

        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.IsReserved = false;
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
        }

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set;  }

        public decimal Price => PricePerPerson * NumberOfPeople;

        public void Reserve(int numberOfPeople)
        {
            IsReserved = true;
            NumberOfPeople = numberOfPeople;
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            decimal bill = this.foodOrders.Sum(f => f.Price);
            bill += this.drinkOrders.Sum(d => d.Price);
            bill += this.Price;
            return bill;
        }

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            this.IsReserved = false;
            this.numberOfPeople = 0;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Price per Person: {PricePerPerson}");
            return sb.ToString().TrimEnd();
        }
    }
}
