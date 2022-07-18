using _04.BorderControl.Contracts;

namespace _04.BorderControl.Models
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
