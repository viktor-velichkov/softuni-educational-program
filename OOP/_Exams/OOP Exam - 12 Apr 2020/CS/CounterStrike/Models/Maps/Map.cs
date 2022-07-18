using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        private const string TERRORISTS_WIN_MESSAGE = "Terrorist wins!";
        private const string COUNTER_TERRORISTS_WIN_MESSAGE = "Counter Terrorist wins!";
        public string Start(ICollection<IPlayer> players)
        {
            
            List<IPlayer> terrorists = players.Where(x => x.GetType().Equals(typeof(Terrorist))).ToList();
            List<IPlayer> counterTerrorists = players.Where(x => x.GetType().Equals(typeof(CounterTerrorist))).ToList();
            while (terrorists.Any(x => x.IsAlive) && counterTerrorists.Any(x => x.IsAlive))
            {
                foreach (var terrorist in terrorists.Where(t=>t.IsAlive))
                {
                    foreach (var counterTerrorist in counterTerrorists.Where(ct => ct.IsAlive))
                    {
                        counterTerrorist.TakeDamage(terrorist.Gun.Fire());
                    }                    
                }
                foreach (var counterTerrorist in counterTerrorists.Where(ct => ct.IsAlive))
                {
                    foreach (var terrorist in terrorists.Where(t => t.IsAlive))
                    {
                        terrorist.TakeDamage(counterTerrorist.Gun.Fire());
                    }
                }
            }
            if (terrorists.Any(x => x.Health > 0))
            {
                return TERRORISTS_WIN_MESSAGE;
            }
            else
            {
                return COUNTER_TERRORISTS_WIN_MESSAGE;
            }
        }
    }
}
