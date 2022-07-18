using Raiding.Common;
using Raiding.Models.Contracts;
using System;

namespace Raiding.Models
{
    public class Healer : BaseHero, IHealer
    {
        public Healer(string name, int power) : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return String.Format(GlobalConstants.HEALER_CAST_MESSAGE, this.GetType().Name, this.Name, this.Power);
        }
    }
}
