using CounterStrike.Core.Contracts;
using CounterStrike.Models.Guns;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository guns;
        private PlayerRepository players;
        private IMap map;


        public Controller()
        {
            this.guns = new GunRepository();
            this.players = new PlayerRepository();
            this.map = new Map();
        }
        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gunToAdd;
            if (type == "Pistol")
            {
                gunToAdd = new Pistol(name, bulletsCount);
            }
            else if (type == "Rifle")
            {
                gunToAdd = new Rifle(name, bulletsCount);
            }
            else
            {
                gunToAdd = null;
            }
            if (gunToAdd == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidGunType);
            }
            else
            {
                this.guns.Add(gunToAdd);
                return String.Format(OutputMessages.SuccessfullyAddedGun, gunToAdd.Name);
            }
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IPlayer playerToAdd;
            IGun playerGun = this.guns.FindByName(gunName);
            if (playerGun == null)
            {
                throw new ArgumentException(ExceptionMessages.GunCannotBeFound);
            }

            if (type == "Terrorist")
            {
                playerToAdd = new Terrorist(username, health, armor, playerGun);
            }
            else if (type == "CounterTerrorist")
            {
                playerToAdd = new CounterTerrorist(username, health, armor, playerGun);
            }
            else
            {
                playerToAdd = null;
            }
            if (playerToAdd == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerType);
            }
            else
            {
                this.players.Add(playerToAdd);
                return String.Format(OutputMessages.SuccessfullyAddedPlayer, playerToAdd.Username);
            }

        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            foreach (var player in this.players.Models.OrderBy(x => x.GetType().Name)
                                                      .ThenByDescending(x => x.Health)
                                                      .ThenBy(x => x.Username))
            {
                result.AppendLine(player.ToString());
            }
            return result.ToString().Trim();
        }

        public string StartGame()
        {
            ICollection<IPlayer> alivePlayers = this.players.Models.Where(x => x.IsAlive).ToList();
            return this.map.Start(alivePlayers);
        }
        public void Exit() { Environment.Exit(0); }
    }
}
