using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._BasicqueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int count = input[0];
            int toDequeue = input[1];
            int toFind = input[2];
            Queue<int> queue = new Queue<int>(count);
            int[] content = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            for (int i = 0; i < count; i++)
            {
                queue.Enqueue(content[i]);
            }
            for (int i = 0; i < toDequeue; i++)
            {
                if (queue.Count != 0)
                {
                    queue.Dequeue();
                }

            }
            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(toFind))
            {
                Console.WriteLine("true");
            }
            else
            {
                int min = int.MaxValue;
                while (queue.Count > 0)
                {
                    if (queue.Peek() <= min)
                    {
                        min = queue.Dequeue();
                    }
                    else
                    {
                        queue.Dequeue();
                    }
                }
                Console.WriteLine(min);
            }
        }
    }
}
