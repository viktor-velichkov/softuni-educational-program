using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int count = input[0];
            int toPop = input[1];
            int toFind = input[2];
            Stack<int> stack = new Stack<int>(count);
            int[] content = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 0; i < count; i++)
            {
                stack.Push(content[i]);
            }
            for (int i = 0; i < toPop; i++)
            {
                if (stack.Count != 0)
                {
                    stack.Pop();
                }

            }
            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(toFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                int min = int.MaxValue;
                while (stack.Count > 0)
                {
                    if (stack.Peek() <= min)
                    {
                        min = stack.Pop();
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
                Console.WriteLine(min);
            }
        }
    }
}
