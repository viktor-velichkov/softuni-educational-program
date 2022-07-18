using WildFarm.Models.Contracts;

namespace WildFarm.Models
{
    public abstract class Bird : Animal, IBird
    {
        private double wingSize;

        protected Bird(string name, double weight,double wingSize) : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get { return this.wingSize; } set { this.wingSize = value; } }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
