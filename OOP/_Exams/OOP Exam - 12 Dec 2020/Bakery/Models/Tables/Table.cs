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
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private bool isReserved;
        public Table()
        {
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
        }
        public Table(int tableNumber, int capacity, decimal pricePerPerson) : this()
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }
        public IReadOnlyCollection<IBakedFood> FoodOrders => this.foodOrders.AsReadOnly();
        public IReadOnlyCollection<IDrink> DrinkOrders => this.drinkOrders.AsReadOnly();
        public int TableNumber
        {
            get { return this.tableNumber; }
            private set
            {
                this.tableNumber = value;
            }
        }

        public int Capacity
        {
            get { return this.capacity; }
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
            get { return this.numberOfPeople; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson
        {
            get { return this.pricePerPerson; }
            private set
            {
                this.pricePerPerson = value;
            }
        }

        public bool IsReserved
        {
            get { return this.isReserved; }
            private set
            {
                this.isReserved = value;
            }
        }

        public decimal Price => this.PricePerPerson * this.NumberOfPeople;

        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
        }

        public decimal GetBill()
        {
            return this.Price
                   + this.foodOrders.Sum(x => x.Price)
                   + this.drinkOrders.Sum(x => x.Price);
        }

        public string GetFreeTableInfo()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Table: {this.TableNumber}");
            result.AppendLine($"Type: {this.GetType().Name}");
            result.AppendLine($"Capacity: {this.Capacity}");
            result.AppendLine($"Price per Person: {this.PricePerPerson}");
            return result.ToString().Trim();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.NumberOfPeople = numberOfPeople;
            this.IsReserved = true;
        }
    }
}
