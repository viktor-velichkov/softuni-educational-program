using Raiding.Models.Contracts;

namespace Raiding.Models
{
    public class Paladin : Healer, IPaladin
    {
        private const int DEFAULT_PALADIN_POWER = 100;
        public Paladin(string name) : base(name, DEFAULT_PALADIN_POWER)
        {
        }
    }
}
