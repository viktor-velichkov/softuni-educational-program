using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace _02._SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] capacities = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = capacities[0];
            int m = capacities[1];
            HashSet<string> setN = new HashSet<string>(n);
            HashSet<string> setM = new HashSet<string>(m);
            

            for (int i = 0; i < n; i++)
            {
                setN.Add(Console.ReadLine());
            }
            for (int i = 0; i < m; i++)
            {
                setM.Add(Console.ReadLine());
            }
            HashSet<string> duplicates = setN.Intersect(setM).ToHashSet();
            Console.WriteLine(String.Join(" ", duplicates));
        }
        
    }
}
