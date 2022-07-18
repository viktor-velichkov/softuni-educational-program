using _07.MilitaryElite.Contracts;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string firstName, string lastName, int id, decimal salary,params int[] privatesIds) : base(firstName, lastName, id, salary)
        {
            this.Privates = new List<IPrivate>();
        }
        public List<IPrivate> Privates { get; set; }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            result.AppendLine("Privates:");
            foreach (var privateSoldier in this.Privates)
            {
                result.AppendLine($"  {privateSoldier.ToString()}");
            }
            return result.ToString().Trim();
        }
    }
}
