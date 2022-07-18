using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Exceptions;
using WildFarm.Models.Contracts;

namespace WildFarm.Models
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string region) : base(name, weight, region)
        {
        }
        protected override double WeightIncrement => 0.40;
        public override string AskForFood()
        {
            return "Woof!";
        }
        public override void Eat(IFood food)
        {
            if (food.GetType().Name != nameof(Meat))
            {
                throw new WrongFoodTypeException(string.Format(ExceptionMessages.WRONG_FOOD_TYPE, this.GetType().Name, food.GetType().Name));
            }
            base.Eat(food);
        }
    }
}
