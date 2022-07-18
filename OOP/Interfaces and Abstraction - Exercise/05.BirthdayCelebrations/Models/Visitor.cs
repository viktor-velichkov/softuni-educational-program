using _05.BirthdayCelebrations.Contracts;

namespace _05.BirthdayCelebrations.Models
{
    public abstract class Visitor : IVisitor
    {
        public Visitor(string id)
        {
            this.Id = id;
        }
        public string Id { get; set; }

        public bool HasInvalidId(string code)
        {
            return this.Id.EndsWith(code);
        }
    }
}
