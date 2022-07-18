using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            int taskToKill = int.Parse(Console.ReadLine());
            bool taskIsKilled = false;
            while (!taskIsKilled)
            {
                int currTask = tasks.Peek();
                int currThread = threads.Peek();
                if (currTask==taskToKill)
                {
                    taskIsKilled = true;
                }
                else
                {
                    if (currThread >= currTask)
                    {
                        threads.Dequeue();
                        tasks.Pop();
                    }
                    else
                    {
                        threads.Dequeue();
                    }
                }
            }
            Console.WriteLine($"Thread with value {threads.Peek()} killed task {taskToKill}");
            Console.WriteLine(String.Join(" ",threads));
        }
    }
}
