﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            Dictionary<double, int> dict = new Dictionary<double, int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (!dict.ContainsKey(input[i]))
                {
                    dict.Add(input[i], 0);
                }
                dict[input[i]]++;
            }
            foreach (var number in dict)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
