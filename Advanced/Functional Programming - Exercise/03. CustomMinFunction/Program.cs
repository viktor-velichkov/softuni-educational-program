using System;
using System.Linq;

namespace _03._CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Func<int[], int> minimum = FindMinimum;
            Console.WriteLine(minimum(numbers));
        }

        static int FindMinimum(int[] numbers)
        {
            int min = int.MaxValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }
            return min;
        }
    }
}
