using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._KeyRevolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int barrelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int bulletsCount = bullets.Length;
            int[] locks = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int intelligenceValue = int.Parse(Console.ReadLine());
            Stack<int> bulletStack = new Stack<int>(bullets);
            Queue<int> locksQueue = new Queue<int>(locks);
            while (locksQueue.Count > 0 && bulletStack.Count > 0)
            {
                bool barrelIsEmpty=true;
                int shots = Math.Min(barrelSize, bulletStack.Count);
                for (int i = 1; i <= shots; i++)
                {
                    int currentBullet = bulletStack.Pop();
                    if (currentBullet <= locksQueue.Peek())
                    {
                        locksQueue.Dequeue();
                        Console.WriteLine("Bang!");
                        if (locksQueue.Count==0)
                        {
                            if (i!=shots)
                            {
                                barrelIsEmpty = false;
                            }
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ping!");
                    }
                }
                if (bulletStack.Count > 0 && barrelIsEmpty)
                {
                    Console.WriteLine("Reloading!");
                }
            }
            if (locksQueue.Count == 0)
            {
                Console.WriteLine($"{bulletStack.Count} bullets left. Earned ${intelligenceValue - (bulletsCount - bulletStack.Count) * bulletPrice}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locksQueue.Count}");
            }
        }
    }
}
