using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input!="END")
                {
                    List<string> list = input.Split(", ".ToCharArray(),StringSplitOptions.RemoveEmptyEntries).ToList();
                    list.RemoveAt(0);
                    string command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray()[0];
                    switch (command)
                    {
                        case "Push":
                            stack.Push(list.Select(int.Parse).ToArray());
                            break;
                        case "Pop":
                            stack.Pop();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        foreach (var item in stack)
                        {
                            Console.WriteLine(item);
                        }
                    }
                    break;
                }

            }
        }
    }
}
