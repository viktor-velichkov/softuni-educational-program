using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for (int i = 0; i < input; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (!dict.ContainsKey(number))
                {
                    dict.Add(number, 0);
                }
                dict[number]++;
            }
            
            foreach (var pair in dict)
            {
                if (pair.Value%2==0)
                {
                    Console.WriteLine(pair.Key);
                    break;
                }
            }
            
        }
    }
}
