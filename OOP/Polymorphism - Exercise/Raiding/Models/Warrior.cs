using Raiding.Models.Contracts;

namespace Raiding.Models
{
    public class Warrior : Attacker, IWarrior
    {
        private const int DEFAULT_WARRIOR_POWER = 100;
        public Warrior(string name) : base(name, DEFAULT_WARRIOR_POWER)
        {
        }
    }
}
