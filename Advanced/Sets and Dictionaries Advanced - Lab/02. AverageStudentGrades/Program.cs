using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputCount = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> dict = new Dictionary<string, List<decimal>>();
            for (int i = 0; i < inputCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string student = input[0];
                decimal grade = decimal.Parse(input[1]);
                if (!dict.ContainsKey(student))
                {
                    dict.Add(student, new List<decimal>());
                }
                dict[student].Add(grade);
            }
            
            foreach (var student in dict)
            {
                Console.Write($"{student.Key} -> ");
                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {student.Value.Average():f2})");
            }
        }
    }
}
