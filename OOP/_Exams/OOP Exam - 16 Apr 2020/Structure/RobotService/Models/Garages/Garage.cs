using RobotService.Models.Garages.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int GARAGE_CAPACITY = 10;
        private readonly IDictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }
        public IReadOnlyDictionary<string, IRobot> Robots => (IReadOnlyDictionary<string, IRobot>)this.robots;

        public void Manufacture(IRobot robot)
        {
            if (this.robots.Count==GARAGE_CAPACITY)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            else if (this.Robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }
            this.robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            IRobot robot = this.robots[robotName];
            robot.IsBought = true;
            robot.Owner = ownerName;
            this.robots.Remove(robotName);
        }
    }
}
