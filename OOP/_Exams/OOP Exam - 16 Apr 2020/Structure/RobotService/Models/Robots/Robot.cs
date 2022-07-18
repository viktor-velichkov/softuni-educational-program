using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private string name;
        private int happiness;
        private int energy;
        private int procedureTime;
        private string owner;
        public Robot(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;
            this.Owner = "Service";
            this.IsBought = false;
            this.IsChipped = false;
            this.IsChecked = false;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
            }
        }

        public int Happiness
        {
            get { return this.happiness; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }
                this.happiness = value;
            }
        }
        public int Energy
        {
            get { return this.energy; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }
                this.energy = value;
            }
        }
        public int ProcedureTime { get { return this.procedureTime; } set { this.procedureTime = value; } }
        public string Owner { get { return this.owner; } set { this.owner = value; } }
        public bool IsBought { get; set; }
        public bool IsChipped { get; set; }
        public bool IsChecked { get; set; }
        public override string ToString()
        {
            return $" Robot type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
