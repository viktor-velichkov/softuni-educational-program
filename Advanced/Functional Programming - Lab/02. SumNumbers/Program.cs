using System;
using System.Linq;

namespace _02._SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            Func<int[], int> sumDelegate = Sum;
            Console.WriteLine(input.Length);
            Console.WriteLine(sumDelegate(input));
        }
        static int Sum(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        }
    }
}
