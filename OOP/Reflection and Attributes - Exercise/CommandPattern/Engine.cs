using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern
{
    public class Engine : IEngine
    {
        private ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }
        public void Run()
        {
            string input;
            while (true)
            {
                input = Console.ReadLine();
                string result = this.commandInterpreter.Read(input);
                Console.WriteLine(result);
            }
        }
    }
}
