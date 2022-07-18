using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public class Hero
    {
        string userName;
        int level;
        public Hero(string userName, int level)
        {
            this.Username = userName;
            this.Level = level;
        }
        public string Username { get { return this.userName; } set { this.userName = value; } }
        public int Level { get { return this.level; } set { this.level = value; } }
        public override string ToString()
        {
            return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";
        }
    }
}
