using _07.MilitaryElite.Exceptions;
using System.Collections.Generic;

namespace _07.MilitaryElite.Models
{
    public class Mission
    {
        private readonly HashSet<string> missionStates = new HashSet<string>() { "Finished", "inProgress" };
        private string codeName;
        private string state;
        public Mission(string codeName,string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }
        public string State
        {
            get { return this.state; }
            set
            {
                if (!missionStates.Contains(value))
                {
                    throw new InvalidMissionStateException();
                }
                this.state = value;
            }
        }

        public string CodeName
        {
            get { return this.codeName; }
            set { this.codeName = value; }
        }
        public void CompleteMission()
        {
            this.State = "Finished";
        }
        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }

    }
}
