namespace Raiding.Models.Contracts
{
    public interface IBaseHero
    {
        public string Name { get;  set; }
        public int Power { get; set; }
        public abstract string CastAbility();
    }
}
