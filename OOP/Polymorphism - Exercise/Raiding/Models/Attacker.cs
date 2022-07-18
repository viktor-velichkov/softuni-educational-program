using Raiding.Common;
using Raiding.Models.Contracts;
using System;

namespace Raiding.Models
{
    public class Attacker : BaseHero, IAttacker
    {
        public Attacker(string name,int power) : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return String.Format(GlobalConstants.ATTACKER_CAST_MESSAGE, this.GetType().Name, this.Name, this.Power);
        }
    }
}
