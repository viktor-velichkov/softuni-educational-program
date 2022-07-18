using WildFarm.Models.Contracts;

namespace WildFarm.Models
{
    public abstract class Feline : Mammal, IFeline
    {
        private string breed;

        protected Feline(string name, double weight, string region,string breed) : base(name, weight, region)
        {
            this.Breed = breed;
        }

        public string Breed { get { return this.breed; } set { this.breed = value; } }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name}, {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
