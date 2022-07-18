namespace WildFarm.Models.Contracts
{
    public interface IBird:IAnimal
    {
        public double WingSize { get; set; }
    }
}
