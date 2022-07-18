using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int allFood = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();
            Stack<int> maxOrder = new Stack<int>();
            queue.Enqueue(orders[0]);
            maxOrder.Push(orders[0]);
            for (int i = 1; i < orders.Length; i++)
            {
                queue.Enqueue(orders[i]);
                if (orders[i]>maxOrder.Peek())
                {
                    maxOrder.Push(orders[i]);
                }
            }
            Console.WriteLine(maxOrder.Pop());
            while (queue.Count>0)
            {
                if (allFood>=queue.Peek())
                {
                    allFood -= queue.Peek();
                    queue.Dequeue();
                }
                else
                {
                    break;
                }
            }
            if (queue.Count==0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine("Orders left: "+String.Join(" ",queue));
            }

        }
    }
}
