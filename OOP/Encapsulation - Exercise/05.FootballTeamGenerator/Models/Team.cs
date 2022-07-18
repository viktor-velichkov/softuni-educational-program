using _05.FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        public readonly List<Player> TeamPlayers;
        public Team()
        {
            this.TeamPlayers = new List<Player>();
        }
        public Team(string name):this()
        {
            this.Name = name;
        }
        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.InvalidNameExceptionMessage);
                }
                this.name = value;
            }
        }
        public int Rating => this.TeamPlayers.Count > 0 ? (int)Math.Round(this.TeamPlayers.Select(x => x.SkillLevel).Average()) : 0;
        public void AddPlayer(Player player)
        {
            this.TeamPlayers.Add(player);
        }
        public void RemovePlayer(Player player)
        {
            if (!this.TeamPlayers.Contains(player))
            {
                throw new ArgumentException(String.Format(GlobalConstants.MissingPlayerExceptionMessage, player.Name, this.Name));
            }
            this.TeamPlayers.Remove(player);
        }
    }
}
