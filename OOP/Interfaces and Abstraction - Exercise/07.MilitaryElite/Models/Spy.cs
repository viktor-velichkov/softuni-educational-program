using _07.MilitaryElite.Contracts;
using System.Globalization;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class Spy : Soldier, ISpy
    {
        private int codeNumber;
        public Spy(string firstName, string lastName, int id, int codeNumber) : base(firstName, lastName, id)
        {
            this.codeNumber = codeNumber;
        }
        public int CodeNumber { get { return this.codeNumber; } set { this.codeNumber = value; } }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");
            result.AppendLine($"Code Number: {this.CodeNumber}");
            return result.ToString().Trim();
        }
    }
}
