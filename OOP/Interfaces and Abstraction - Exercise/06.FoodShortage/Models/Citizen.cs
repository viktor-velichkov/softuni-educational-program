using _06.FoodShortage.Contracts;

namespace _06.FoodShortage.Models
{
    public class Citizen : Visitor, IBeing, IPerson, IVisitor, IBuyer
    {
        string name;
        int age;
        string birthdate;
        int food;
        public Citizen(string id) : base(id)
        {

        }
        public Citizen(string name, int age, string id) : this(id)
        {
            this.Name = name;
            this.Age = age;
        }
        public Citizen(string name, int age, string id, string birthdate) : this(name, age, id)
        {
            this.Birthdate = birthdate;
        }
        public string Name { get { return this.name; } set { this.name = value; } }
        public int Age { get { return this.age; } set { this.age = value; } }

        public string Birthdate { get { return this.birthdate; } set { this.birthdate = value; } }

        public int Food { get { return this.food; } set { this.food = value; } }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}
