using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Text;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string userName;
        private int health;
        private int armor;
        private IGun gun;

        public Player(string userName, int health,int armor, IGun gun)
        {
            this.Username = userName;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
        }
        public string Username
        {
            get { return this.userName; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }
                this.userName = value;
            }
        }

        public int Health
        {
            get { return this.health; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }
                this.health = value;
            }
        }

        public int Armor
        {
            get { return this.armor; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }
                this.armor = value;
            }
        }
        public IGun Gun
        {
            get { return this.gun; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }
                this.gun = value;
            }
        }

        public bool IsAlive { get { return this.Health > 0; } }

        public void TakeDamage(int points)
        {
            if (this.IsAlive)
            {
                if (this.armor >= points)
                {
                    this.armor -= points;
                }
                else
                {
                    this.health -= (points - this.armor);
                    this.armor = 0;
                }
                if (this.health < 0)
                {
                    this.health = 0;
                }
            }            
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{this.GetType().Name}: {this.Username}");
            result.AppendLine($"--Health: {this.Health}");
            result.AppendLine($"--Armor: {this.Armor}");
            result.AppendLine($"--Gun: {this.Gun.Name}");
            return result.ToString().Trim();
        }
    }
}
