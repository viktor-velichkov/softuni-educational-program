using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>(clothes);
            int racksCount = 1;
            int currentRackSum = 0;
            while (stack.Count>0)
            {
                if (stack.Peek()+currentRackSum<=rackCapacity)
                {
                    currentRackSum += stack.Pop();
                }
                else
                {
                    racksCount++;
                    currentRackSum = stack.Pop();
                }
            }
            Console.WriteLine(racksCount);

        }
    }
}
