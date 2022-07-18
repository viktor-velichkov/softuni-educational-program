using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Exceptions;
using System;
using System.Collections.Generic;

namespace _07.MilitaryElite.Models
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private readonly HashSet<string> corpses = new HashSet<string>() { "Airforces", "Marines" };
        string corps;
        public SpecialisedSoldier(string firstName, string lastName, int id, decimal salary, string corps) : base(firstName, lastName, id, salary)
        {
            this.Corps = corps;
        }
        public string Corps
        {
            get { return this.corps; }
            set
            {
                if (!corpses.Contains(value))
                {
                    throw new InvalidCorpsException();
                }
                this.corps = value;
            }
        }
    }
}
