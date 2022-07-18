namespace WildFarm.Models.Contracts
{
    public interface IAnimal
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten { get; set; }
        public string AskForFood();
        public void Eat(IFood food);
    }
}
