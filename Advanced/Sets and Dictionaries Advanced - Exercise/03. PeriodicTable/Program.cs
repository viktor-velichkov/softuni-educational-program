using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> elements = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                foreach (var item in input)
                {
                    elements.Add(item);
                }
            }
            var sortedElements = elements.OrderBy(x => x);
            Console.WriteLine(string.Join(" ",sortedElements));
        }
        
    }
}
