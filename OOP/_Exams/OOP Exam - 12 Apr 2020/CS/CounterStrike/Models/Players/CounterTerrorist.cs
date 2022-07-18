using CounterStrike.Models.Guns.Contracts;

namespace CounterStrike.Models.Players
{
    public class CounterTerrorist : Player
    {
        public CounterTerrorist(string userName, int health, int armor, IGun gun) : base(userName, health, armor, gun)
        {
        }
    }
}
