using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ClubParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int hallsCapacity = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray());
            Dictionary<char, List<int>> hallsData = new Dictionary<char, List<int>>();
            Queue<string> halls = new Queue<string>();
            bool isThereOpenHall = false;
            List<int> currReservations = new List<int>();
            int currentCapacity = hallsCapacity;
            while (stack.Count > 0)
            {
                string nextElement = stack.Peek();
                if (!int.TryParse(nextElement, out int result))
                {
                    halls.Enqueue(stack.Pop());
                    isThereOpenHall = true;
                }
                else
                {
                    if (isThereOpenHall)
                    {
                        if (currentCapacity >= result)
                        {
                            currReservations.Add(result);
                            currentCapacity -= result;
                            stack.Pop();
                        }
                        else
                        {
                            Console.WriteLine($"{halls.Dequeue()} -> {String.Join(", ", currReservations)}");
                            currReservations.Clear();
                            currentCapacity = hallsCapacity;
                            if (halls.Count == 0)
                            {
                                isThereOpenHall = false;
                                stack.Pop();
                            }
                            else
                            {
                                if (currentCapacity >= result)
                                {
                                    currReservations.Add(result);
                                    currentCapacity -= result;
                                }
                                stack.Pop();
                            }
                        }
                    }
                    else
                    {
                        stack.Pop();
                    }
                }
            }
        }
    }
}
