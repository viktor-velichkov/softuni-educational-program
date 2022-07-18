using WildFarm.Exceptions;
using WildFarm.Models.Contracts;

namespace WildFarm.Models
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string region) : base(name, weight, region)
        {
        }
        protected override double WeightIncrement => 0.10;
        public override string AskForFood()
        {
            return "Squeak";
        }
        public override void Eat(IFood food)
        {
            if (food.GetType().Name != nameof(Vegetable)&& food.GetType().Name != nameof(Fruit))
            {
                throw new WrongFoodTypeException(string.Format(ExceptionMessages.WRONG_FOOD_TYPE, this.GetType().Name, food.GetType().Name));
            }
            base.Eat(food);
        }
    }
}
