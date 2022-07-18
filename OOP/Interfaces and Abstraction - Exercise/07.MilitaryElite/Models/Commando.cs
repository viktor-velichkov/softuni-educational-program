using _07.MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string firstName, string lastName, int id, decimal salary, string corps) : base(firstName, lastName, id, salary, corps)
        {
            this.Missions = new List<Mission>();
        }
        public List<Mission> Missions { get; set; }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            result.AppendLine($"Corps: {this.Corps}");
            result.AppendLine("Missions:");
            foreach (var mission in this.Missions)
            {
                result.AppendLine($"  {mission.ToString()}");
            }
            return result.ToString().Trim();
        }
    }
}
