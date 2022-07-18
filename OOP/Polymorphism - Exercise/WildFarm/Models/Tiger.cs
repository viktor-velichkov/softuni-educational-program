using WildFarm.Exceptions;
using WildFarm.Models.Contracts;

namespace WildFarm.Models
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string region, string breed) : base(name, weight, region, breed)
        {
        }

        public override string AskForFood()
        {
            return "ROAR!!!";
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
