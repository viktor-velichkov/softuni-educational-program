using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._MaximumАndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < count; i++)
            {
                int[] query = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int action = query[0];
                switch (action)
                {
                    case 1:
                        stack.Push(query[1]);
                        break;
                    case 2:
                        if (stack.Count != 0)
                        {
                            stack.Pop();
                        }
                        break;
                    case 3:
                        if (stack.Count==0)
                        {
                            continue;
                        }
                        else
                        {
                            int max = int.MinValue;
                            Stack<int> secondStack = new Stack<int>();
                            while (stack.Count > 0)
                            {
                                if (stack.Peek() > max)
                                {
                                    max = stack.Peek();
                                }
                                secondStack.Push(stack.Pop());
                            }
                            while (secondStack.Count > 0)
                            {
                                stack.Push(secondStack.Pop());
                            }
                            Console.WriteLine(max);
                        }
                        break;
                    case 4:
                        if (stack.Count==0)
                        {
                            continue;
                        }
                        else
                        {
                            int min = int.MaxValue;
                            Stack<int> newStack = new Stack<int>();
                            while (stack.Count > 0)
                            {
                                if (stack.Peek() < min)
                                {
                                    min = stack.Peek();
                                }
                                newStack.Push(stack.Pop());
                            }
                            while (newStack.Count > 0)
                            {
                                stack.Push(newStack.Pop());
                            }
                            Console.WriteLine(min);
                        }
                        break;
                }
            }
            Console.WriteLine(String.Join(", ", stack));
        }
    }
}
