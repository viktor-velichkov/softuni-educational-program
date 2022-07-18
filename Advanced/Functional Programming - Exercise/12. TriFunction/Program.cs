using System;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Func<string[], int, string> findFirstMatch = FindMatch;
            Console.WriteLine(findFirstMatch(names, N));
        }
        static bool IsMatch(int sum, int number)
        {
            return sum >= number;
        }
        static string FindMatch(string[] array, int number)
        {
            string result = "";
            Func<int, int, bool> isMatch = IsMatch;
            Func<string, int> sumOfChars = SumOfCharacters;
            foreach (var item in array)
            {
                if (isMatch(sumOfChars(item), number))
                {
                    result = item;
                    break;
                }
            }
            return result;
        }
        static int SumOfCharacters(string name)
        {
            int sum = 0;
            for (int i = 0; i < name.Length; i++)
            {
                sum += (int)name[i];
            }
            return sum;
        }
    }
}
