using WildFarm.Exceptions;
using WildFarm.Models.Contracts;

namespace WildFarm.Models
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string region, string breed) : base(name, weight, region, breed)
        {
        }
        protected override double WeightIncrement => 0.30;
        public override string AskForFood()
        {
            return "Meow";
        }
        public override void Eat(IFood food)
        {
            if (food.GetType().Name != nameof(Vegetable) && food.GetType().Name != nameof(Meat))
            {
                throw new WrongFoodTypeException(string.Format(ExceptionMessages.WRONG_FOOD_TYPE,this.GetType().Name,food.GetType().Name));
            }
            base.Eat(food);
        }
    }
}
