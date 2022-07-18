namespace WildFarm.Models.Contracts
{
    public interface IMammal : IAnimal
    {
        public string LivingRegion { get; set; }
    }
}
