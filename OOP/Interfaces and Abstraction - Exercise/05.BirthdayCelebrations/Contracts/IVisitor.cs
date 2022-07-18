namespace _05.BirthdayCelebrations.Contracts
{
    public interface IVisitor
    {
        public string Id { get; set; }
        public bool HasInvalidId(string code);        
    }
}
