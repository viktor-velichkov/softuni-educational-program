using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] input = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string commandName = (input[0]+"Command").ToLower();
            string[] commandArgs = input.Skip(1).ToArray();
            ICommand command = null;
            Type commandType = Assembly.GetCallingAssembly().GetTypes().FirstOrDefault(x=>x.Name.ToLower()==commandName);
            command = (ICommand)Activator.CreateInstance(commandType);
            string result = command.Execute(commandArgs);
            return result;        
        }
    }
}
