using RobotService.Core.Contracts;
using RobotService.Models.Garages;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures;
using RobotService.Models.Robots;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private readonly IGarage garage;
        private readonly Charge chargeProcedure = new Charge();
        private readonly Chip chipProcedure = new Chip();
        private readonly Polish polishProcedure = new Polish();
        private readonly Rest restProcedure = new Rest();
        private readonly TechCheck techCheckProcedure = new TechCheck();
        private readonly Work workProcedure = new Work();

        public Controller(IGarage garage)
        {
            this.garage = garage;
        }
        public Controller() : this(new Garage())
        {

        }
        public string Charge(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            IRobot robot = this.garage.Robots[robotName];
            chargeProcedure.DoService(robot, procedureTime);
            return String.Format(OutputMessages.ChargeProcedure, robot.Name);
        }

        public string Chip(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            IRobot robot = this.garage.Robots[robotName];
            chipProcedure.DoService(robot, procedureTime);
            return String.Format(OutputMessages.ChipProcedure, robot.Name);
        }

        public string History(string procedureType)
        {
            switch (procedureType)
            {
                case "Charge":
                    return chargeProcedure.History();
                case "Chip":
                    return chipProcedure.History();
                case "Polish":
                    return polishProcedure.History();
                case "Rest":
                    return restProcedure.History();
                case "TechCheck":
                    return techCheckProcedure.History();
                case "Work":
                    return workProcedure.History();
                default:
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidProcedureType, procedureType));
            }
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot;
            switch (robotType)
            {
                case "HouseholdRobot":
                    robot = new HouseholdRobot(name, energy, happiness, procedureTime);
                    break;
                case "PetRobot":
                    robot = new PetRobot(name, energy, happiness, procedureTime);
                    break;
                case "WalkerRobot":
                    robot = new WalkerRobot(name, energy, happiness, procedureTime);
                    break;
                default:
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidRobotType, robotType));
            }
            this.garage.Manufacture(robot);
            return String.Format(OutputMessages.RobotManufactured, robot.Name);
        }

        public string Polish(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            IRobot robot = this.garage.Robots[robotName];
            polishProcedure.DoService(robot, procedureTime);
            return String.Format(OutputMessages.PolishProcedure, robot.Name);
        }

        public string Rest(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            IRobot robot = this.garage.Robots[robotName];
            restProcedure.DoService(robot, procedureTime);
            return String.Format(OutputMessages.RestProcedure, robot.Name);
        }

        public string Sell(string robotName, string ownerName)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            IRobot robot = this.garage.Robots[robotName];
            this.garage.Sell(robotName, ownerName);
            if (robot.IsChipped)
            {
                return String.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                return String.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            IRobot robot = this.garage.Robots[robotName];
            techCheckProcedure.DoService(robot, procedureTime);
            return String.Format(OutputMessages.TechCheckProcedure, robot.Name);
        }

        public string Work(string robotName, int procedureTime)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
            IRobot robot = this.garage.Robots[robotName];
            workProcedure.DoService(robot, procedureTime);
            return String.Format(OutputMessages.WorkProcedure, robot.Name, procedureTime);
        }
        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
