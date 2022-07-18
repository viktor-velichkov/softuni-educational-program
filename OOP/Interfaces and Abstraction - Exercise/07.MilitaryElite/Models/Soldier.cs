using _07.MilitaryElite.Contracts;

namespace _07.MilitaryElite.Models
{
    public class Soldier:ISoldier
    {
        private string firstName;
        private int id;
        private string lastName;
        public Soldier(string firstName, string lastName, int id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
        }
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }

    }
}
