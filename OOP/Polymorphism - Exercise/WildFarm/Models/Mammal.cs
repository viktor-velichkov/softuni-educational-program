using WildFarm.Models.Contracts;

namespace WildFarm.Models
{
    public abstract class Mammal : Animal, IMammal
    {
        private string livingRegion;

        protected Mammal(string name, double weight,string region) : base(name, weight)
        {
            this.LivingRegion = region;
        }

        public string LivingRegion { get { return this.livingRegion; } set { this.livingRegion = value; } }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
