using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder();
            Stack<string> stack = new Stack<string>();
            int operationsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < operationsCount; i++)
            {
                string[] command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string action = command[0];
                switch (action)
                {
                    case "1":
                        string addition = command[1];
                        AddText(text, addition);
                        stack.Push(action += $" {addition.Length}");
                        break;
                    case "2":
                        int symbolsToRemove = int.Parse(command[1]);
                        string removedString = RemoveText(text, symbolsToRemove);
                        stack.Push(action += $" {removedString}");
                        break;
                    case "3":
                        int index = int.Parse(command[1]) - 1;
                        Console.WriteLine(text[index]);
                        break;
                    case "4":
                        string stackLast = stack.Pop();
                        string[] lastOperation = stackLast.Split().ToArray();
                        string operationCode = lastOperation[0];
                        if (operationCode == "1")
                        {
                            RemoveText(text, int.Parse(lastOperation[1]));
                        }
                        else if (operationCode == "2")
                        {
                            AddText(text, lastOperation[1]);
                        }
                        break;
                    default:
                        Console.WriteLine("Error");
                        break;
                }
            }
        }
        static void AddText(StringBuilder text, string stringToAdd)
        {
            text.Append(stringToAdd);
        }
        static string RemoveText(StringBuilder text, int symbolsCount)
        {
            string removedString = text.ToString().Substring(text.Length - symbolsCount, symbolsCount);
            text.Remove(text.Length - symbolsCount, symbolsCount);
            return removedString;
        }
    }
}
