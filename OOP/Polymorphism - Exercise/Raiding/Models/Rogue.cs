using Raiding.Models.Contracts;

namespace Raiding.Models
{
    public class Rogue : Attacker, IRogue
    {
        private const int DEFAULT_ROGUE_POWER = 80;
        public Rogue(string name) : base(name, DEFAULT_ROGUE_POWER)
        {
        }
    }
}
