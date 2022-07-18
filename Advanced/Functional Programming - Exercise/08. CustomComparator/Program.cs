using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;

namespace _08._CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
           
            
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Array.Sort(input);
            Func<int[], int[]> sort = EvenThenOdd;
            Console.WriteLine(string.Join(" ",sort(input)));
            
           
        }
        static int[] EvenThenOdd(int[] array)
        {
            int[] result = new int[array.Length];
            var evenNums = array.Where(x => x % 2 == 0).ToArray();
            var oddNums = array.Where(x => x % 2 != 0).ToArray();
            for (int i = 0; i < array.Length; i++)
            {
                if(i<evenNums.Length)
                { 
                    result[i] = evenNums[i];
                }
                else
                {
                    result[i] = oddNums[i-evenNums.Length];
                }
            }
            return result;
        }

    }
}
