using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._CupsAndBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] bottles = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> bottlesStack = new Stack<int>(bottles);
            Queue<int> cupsQueue = new Queue<int>(cups);
            int wastedWater = 0;
            while (bottlesStack.Count > 0 && cupsQueue.Count > 0)
            {
                int currentCup = cupsQueue.Peek();
                while (currentCup > 0)
                {
                    if (bottlesStack.Count > 0)
                    {
                        int currentBottle = bottlesStack.Pop();
                        if (currentBottle < currentCup)
                        {
                            currentCup -= currentBottle;
                        }
                        else
                        {
                            wastedWater += currentBottle - currentCup;
                            currentCup = 0;
                            cupsQueue.Dequeue();
                        }
                    }
                    else
                    {
                        break;
                    }

                }
            }
            if (bottlesStack.Count == 0)
            {
                Console.WriteLine($"Cups: {String.Join(" ", cupsQueue)}");
                cupsQueue.Clear();
            }
            else if (cupsQueue.Count == 0)
            {
                Console.WriteLine($"Bottles: {String.Join(" ", bottlesStack)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
