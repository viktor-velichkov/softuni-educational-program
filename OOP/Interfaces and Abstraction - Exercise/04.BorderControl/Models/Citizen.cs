using _04.BorderControl.Contracts;

namespace _04.BorderControl.Models
{
    public class Citizen : Visitor, IVisitor
    {
        string name;
        int age;
        public Citizen(string id):base(id)
        {

        }
        public Citizen(string name, int age,string id):this(id)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get { return this.name; } private set { this.name = value; } }
        public int Age { get { return this.age; } set { this.age = value; } }
    }
}
