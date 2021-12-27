using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private IList<IBakedFood> bakedFoods;
        private IList<IDrink> drinks;
        private IList<ITable> tables;
        private decimal TotalRestaurantIncome;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
            this.TotalRestaurantIncome = 0m;
        }

        public string AddFood(string type, string name, decimal price)
        {
            if (type == nameof(Bread))
            {
                bakedFoods.Add(new Bread(name, price));
            }
            
            if (type == nameof(Cake))
            {
                bakedFoods.Add(new Cake(name, price));
            }

            return string.Format(OutputMessages.FoodAdded, name, type);
        }


        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type == nameof(Water))
            {
                drinks.Add(new Water(name, portion, brand));
            }

            if (type == nameof(Tea))
            {
                drinks.Add(new Tea(name, portion, brand));
            }

            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == nameof(InsideTable))
            {
                this.tables.Add(new InsideTable(tableNumber, capacity));
            }

            if (type == nameof(OutsideTable))
            {
                this.tables.Add(new OutsideTable(tableNumber, capacity));
            }

            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables.FirstOrDefault(t => t.Capacity >= numberOfPeople && !t.IsReserved);
            if (table == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            table.Reserve(numberOfPeople);
            return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IDrink drink = drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);

            return $"Table {table.TableNumber} ordered {drink.Name} {drink.Brand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IBakedFood bakedFood = bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (bakedFood == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(bakedFood);

            return string.Format(OutputMessages.FoodOrderSuccessful, table.TableNumber, bakedFood.Name);
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            if (table == null)
            {
                throw new ArgumentException(string.Format(OutputMessages.WrongTableNumber, tableNumber));
            }

            var totalTableSum = table.GetBill();
            this.TotalRestaurantIncome += totalTableSum;
            table.Clear();

            var sb = new StringBuilder();
            sb.AppendLine($"Table: {tableNumber}");
            sb.AppendLine($"Bill: {totalTableSum:f2}");
            return sb.ToString().TrimEnd();
        }

        public string GetFreeTablesInfo()
        {
            var notReservedTables = tables
                .Where(t => t.IsReserved == false)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var table in notReservedTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return string.Format(OutputMessages.TotalIncome, TotalRestaurantIncome);
        }


    }
}
