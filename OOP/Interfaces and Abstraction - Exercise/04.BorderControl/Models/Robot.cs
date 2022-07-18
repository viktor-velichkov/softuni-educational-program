using _04.BorderControl.Contracts;

namespace _04.BorderControl.Models
{
    public class Robot:Visitor,IVisitor
    {
        string model;
        public Robot(string id):base(id)
        {

        }
        public Robot(string model, string id) : this(id)
        {
            this.Model = model;
        }
        public string Model { get { return this.model; } private set { this.model = value; } }
    }
}
