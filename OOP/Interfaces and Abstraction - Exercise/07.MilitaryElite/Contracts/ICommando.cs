using _07.MilitaryElite.Models;
using System.Collections.Generic;

namespace _07.MilitaryElite.Contracts
{
    public interface ICommando:ISpecialisedSoldier
    {
        public List<Mission> Missions { get; set; }
    }
}
