using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._SortEveнNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            Func<int[], int[]> filterEven = FilterEvenNumbers;
            Action<int[]> printArraySorted = PrintArraySorted;
            printArraySorted(filterEven(input));
        }

        static int[] FilterEvenNumbers(int[] array)
        {
            List<int> evenNums = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    evenNums.Add(array[i]);
                }
            }
            return evenNums.ToArray();
        }

        static void PrintArraySorted(int[] array)
        {
            Console.WriteLine(String.Join(", ",array.OrderBy(x=>x)));
        }
    }
}
