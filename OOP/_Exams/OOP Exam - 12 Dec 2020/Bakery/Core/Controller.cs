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
        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome = 0;
        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = CreateDrink(type, name, portion, brand);
            if (drink == null)
            {
                throw new ArgumentException("Invalid drink type!");
            }
            this.drinks.Add(drink);
            return String.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = CreateFood(type, name, price);
            if (food == null)
            {
                throw new ArgumentException("Invalid food type!");
            }
            this.bakedFoods.Add(food);
            return String.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = CreateTable(type, tableNumber, capacity);
            if (table == null)
            {
                throw new ArgumentException("Invalid table type!");
            }
            this.tables.Add(table);
            return String.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder result = new StringBuilder();
            foreach (var table in this.tables.Where(x => x.IsReserved == false))
            {
                result.AppendLine(table.GetFreeTableInfo());
            }
            return result.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {this.totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            decimal bill = table.GetBill();
            this.totalIncome += bill;
            table.Clear();
            return $"Table: {tableNumber}{Environment.NewLine}Bill: {bill:f2}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            IDrink drink = this.drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);
            if (drink == null)
            {
                return String.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }
            table.OrderDrink(drink);
            return String.Format(OutputMessages.DrinkOrderSuccessful, tableNumber, drinkName, drinkBrand);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            IBakedFood food = this.bakedFoods.FirstOrDefault(x => x.Name == foodName);
            if (food == null)
            {
                return String.Format(OutputMessages.NonExistentFood, foodName);
            }
            table.OrderFood(food);
            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable[] freeTables = this.tables.Where(x => x.IsReserved == false && x.Capacity >= numberOfPeople).ToArray();
            if (freeTables.Length == 0)
            {
                return String.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            ITable table = freeTables.First();
            table.Reserve(numberOfPeople);
            return String.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
        }

        private IBakedFood CreateFood(string type, string name, decimal price)
        {
            IBakedFood food;
            switch (type)
            {
                case "Bread":
                    food = new Bread(name, price);
                    break;
                case "Cake":
                    food = new Cake(name, price);
                    break;
                default:
                    food = null;
                    break;
            }
            return food;
        }
        private IDrink CreateDrink(string type, string name, int portion, string brand)
        {
            IDrink drink;
            switch (type)
            {
                case "Tea":
                    drink = new Tea(name, portion, brand);
                    break;
                case "Water":
                    drink = new Water(name, portion, brand);
                    break;
                default:
                    drink = null;
                    break;
            }
            return drink;
        }

        private ITable CreateTable(string type, int tableNumber, int capacity)
        {
            ITable table;
            switch (type)
            {
                case "InsideTable":
                    table = new InsideTable(tableNumber, capacity);
                    break;
                case "OutsideTable":
                    table = new OutsideTable(tableNumber, capacity);
                    break;
                default:
                    table = null;
                    break;
            }
            return table;
        }


    }
}
