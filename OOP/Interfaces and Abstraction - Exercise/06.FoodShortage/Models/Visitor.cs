using _06.FoodShortage.Contracts;

namespace _06.FoodShortage.Models
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
