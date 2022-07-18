using _07.MilitaryElite.Contracts;

namespace _07.MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        decimal salary;
        public Private(string firstName, string lastName, int id,decimal salary) : base(firstName,lastName,id)
        {
            this.Salary = salary;
        }
        public decimal Salary { get { return this.salary; } set { this.salary = value; } }
        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}";
        }
    }
}
