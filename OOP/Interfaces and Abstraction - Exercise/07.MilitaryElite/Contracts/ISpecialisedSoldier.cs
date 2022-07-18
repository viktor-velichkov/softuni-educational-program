using System;

namespace _07.MilitaryElite.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        public string Corps { get; set; }
    }
}
