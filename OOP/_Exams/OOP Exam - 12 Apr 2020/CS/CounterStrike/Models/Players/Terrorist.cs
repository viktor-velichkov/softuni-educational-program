using CounterStrike.Models.Guns.Contracts;

namespace CounterStrike.Models.Players
{
    public class Terrorist : Player
    {
        public Terrorist(string userName, int health, int armor, IGun gun) : base(userName, health, armor, gun)
        {
        }
    }
}
