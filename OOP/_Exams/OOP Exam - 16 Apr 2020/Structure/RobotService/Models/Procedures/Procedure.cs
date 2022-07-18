using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        private readonly ICollection<IRobot> robots;
        public Procedure()
        {
            this.robots = new List<IRobot>();
        }
        protected IReadOnlyCollection<IRobot> Robots => this.robots.ToList().AsReadOnly();

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }
            robot.ProcedureTime -= procedureTime;
            this.robots.Add(robot);
        }

        public string History()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{this.GetType().Name}");
            foreach (var robot in this.robots)
            {
                result.AppendLine(robot.ToString());
            }
            return result.ToString().Trim();
        }
    }
}
