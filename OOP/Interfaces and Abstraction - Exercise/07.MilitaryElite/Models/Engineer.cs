using _07.MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string firstName, string lastName, int id, decimal salary, string corps) : base(firstName, lastName, id, salary, corps)
        {
            this.Repairs = new List<Repair>();
        }
        public List<Repair> Repairs { get; set; }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            result.AppendLine($"Corps: {this.Corps}");
            result.AppendLine("Repairs:");
            foreach (var repair in this.Repairs)
            {
                result.AppendLine($"  {repair.ToString()}");
            }
            return result.ToString().Trim();
        }
    }
}
