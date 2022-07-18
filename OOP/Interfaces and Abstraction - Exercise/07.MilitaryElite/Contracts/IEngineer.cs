using _07.MilitaryElite.Models;
using System.Collections.Generic;

namespace _07.MilitaryElite.Contracts
{
    interface IEngineer:ISpecialisedSoldier
    {
        public List<Repair> Repairs { get; set; }
    }
}
