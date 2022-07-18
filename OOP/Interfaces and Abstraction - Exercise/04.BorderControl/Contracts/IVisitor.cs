namespace _04.BorderControl.Contracts
{
    public interface IVisitor
    {
        public string Id { get; set; }
        public bool HasInvalidId(string code);        
    }
}
