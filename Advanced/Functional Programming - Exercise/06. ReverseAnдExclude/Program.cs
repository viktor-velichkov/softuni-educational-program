using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<int[], int> reverseAndExclude = ReverseAndExclude;
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int divider = int.Parse(Console.ReadLine());
            reverseAndExclude(input, divider);

        }
        static void ReverseAndExclude(int[] array, int number)
        {
            List<int> list = array.Reverse().ToList();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % number == 0)
                {
                    list.RemoveAt(i--);

                }
            }
            Console.WriteLine(String.Join(" ", list));
        }
    }
}
