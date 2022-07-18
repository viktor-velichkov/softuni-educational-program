using System;
using System.Linq;

namespace _09._ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Func<int, int[]> sequenceGenerator = SequenceGenerator;
            Func<int, int[], bool> check = IsDivisible;

            Console.WriteLine(String.Join(" ",sequenceGenerator(N).Where((x,y) =>check(x,dividers))));

        }

        static bool IsDivisible(int number, int[] array)
        {
            bool isDivisible = true;
            foreach (var item in array)
            {
                if (number % item != 0)
                {
                    isDivisible = false;
                    break;
                }
            }
            return isDivisible;
        }
        static int[] SequenceGenerator(int end)
        {
            int[] sequence = new int[end];

            for (int i = 0; i < sequence.Length; i++)
            {
                sequence[i] = i+1;
            }
            return sequence;
        }
    }
}
