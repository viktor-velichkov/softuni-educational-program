namespace _06.FoodShortage.Contracts
{
    public interface IVisitor
    {
        public string Id { get; set; }
        public bool HasInvalidId(string code);        
    }
}
