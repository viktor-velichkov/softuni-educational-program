using _05.FootballTeamGenerator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator.Models
{
    public class Player
    {
        private const int MIN_STAT = 0;
        private const int MAX_STAT = 100;
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
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

        public int Endurance
        {
            get { return this.endurance; }
            private set
            {
                this.ValidateStat(nameof(Endurance), value);
                this.endurance = value;
            }
        }

        public int Sprint
        {
            get { return this.sprint; }
            private set
            {
                this.ValidateStat(nameof(Sprint), value);
                this.sprint = value;
            }
        }

        public int Dribble
        {
            get { return this.dribble; }
            private set
            {
                this.ValidateStat(nameof(Dribble), value);
                this.dribble = value;
            }
        }

        public int Passing
        {
            get { return this.passing; }
            private set
            {
                this.ValidateStat(nameof(Passing), value);
                this.passing = value;
            }
        }

        public int Shooting
        {
            get { return this.shooting; }
            private set
            {
                this.ValidateStat(nameof(Shooting), value);
                this.shooting = value;
            }
        }
        public double SkillLevel => new int[5] { this.Endurance, this.Sprint, this.Dribble, this.Passing, this.Shooting }.Average();

        private void ValidateStat(string name, int stat)
        {
            if (stat < MIN_STAT || stat > MAX_STAT)
            {
                throw new ArgumentException(String.Format(GlobalConstants.InvalidStatExceptionMessage, name));
            }
        }
    }
}
