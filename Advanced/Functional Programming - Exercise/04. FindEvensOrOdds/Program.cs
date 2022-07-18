using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _04._FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            string condition = Console.ReadLine();
            int[] sequence = SequenceGenerator(range[0], range[1]);
            Func<int, bool> conditionDelegate = GetCondition(condition);
            var result = sequence.Where(conditionDelegate);
            Console.WriteLine(string.Join(" ", result));

        }
        static Func<int, bool> GetCondition(string type)
        {
            switch (type)
            {
                case "even":
                    return x => IsEven(x);
                case "odd":
                    return x => IsOdd(x);
                default:
                    return null;
            }
        }
        static bool IsEven(int number)
        {
            return number % 2 == 0;
        }
        static bool IsOdd(int number)
        {
            return number % 2 != 0;
        }
        static int[] SequenceGenerator(int start, int end)
        {
            int[] sequence = new int[end - start + 1];

            for (int i = 0; i < sequence.Length; i++)
            {
                sequence[i] = start;
                start++;
            }
            return sequence;
        }
    }
}
