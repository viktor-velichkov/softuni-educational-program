using System;
using System.Linq;

namespace _07._PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            Predicate<string> predicate = x => x.Length <= length;
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (var name in Array.FindAll(input,predicate))
            {
                Console.WriteLine(name);
            }
        }
    }
}
