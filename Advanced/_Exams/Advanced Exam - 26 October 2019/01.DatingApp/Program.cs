using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.DatingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] males = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] females = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> malesStack = new Stack<int>(males);
            Queue<int> femalesQueue = new Queue<int>(females);
            int matches = 0;
            while (malesStack.Count > 0 && femalesQueue.Count > 0)
            {
                int currentMale = malesStack.Peek();
                int currentFemale = femalesQueue.Peek();
                if (currentMale<=0)
                {
                    malesStack.Pop();
                }
                else if (currentFemale<=0)
                {
                    femalesQueue.Dequeue();
                }
                else if (currentMale%25==0)
                {
                    malesStack.Pop();
                    if (malesStack.Count>0)
                    {
                        malesStack.Pop();
                    }                    
                }
                else if (currentFemale % 25 == 0)
                {
                    femalesQueue.Dequeue();
                    if (femalesQueue.Count > 0)
                    {
                        femalesQueue.Dequeue();
                    }
                }
                else if (currentMale==currentFemale)
                {
                    malesStack.Pop();
                    femalesQueue.Dequeue();
                    matches++;
                }
                else
                {
                    malesStack.Pop();
                    femalesQueue.Dequeue();
                    malesStack.Push(currentMale - 2);
                }
            }
            Console.WriteLine($"Matches: {matches}");
            if (malesStack.Count == 0)
            {
                Console.WriteLine("Males left: none");
            }
            else
            {
                Console.WriteLine($"Males left: {String.Join(", ", malesStack)}");
            }
            if (femalesQueue.Count == 0)
            {
                Console.WriteLine("Females left: none");
            }
            else
            {
                Console.WriteLine($"Females left: {String.Join(", ", femalesQueue)}");
            }

        }
    }
}
