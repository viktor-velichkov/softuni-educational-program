namespace WildFarm.Models
{
    public class Hen : Bird
    {
        
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }
        protected override double WeightIncrement => 0.35;
        public override string AskForFood()
        {
            return "Cluck";
        }
    }
}
