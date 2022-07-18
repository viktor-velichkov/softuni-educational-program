using WildFarm.Models.Contracts;

namespace WildFarm.Models
{
    public abstract class Animal : IAnimal
    {

        private string name;
        private double weight;
        private int foodEaten;

        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get { return this.name; } set { this.name = value; } }
        public double Weight { get { return this.weight; } set { this.weight = value; } }
        public int FoodEaten { get { return this.foodEaten; } set { this.foodEaten = value; } }
        protected virtual double WeightIncrement => 1.00;
        public virtual void Eat(IFood food)
        {
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * WeightIncrement;
        }
        public abstract string AskForFood();
    }
}
