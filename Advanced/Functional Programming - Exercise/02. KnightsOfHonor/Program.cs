using System;
using System.Linq;

namespace _02._KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Action<string[]> addSir = AddSir;
            addSir(input);

        }
        static void AddSir(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Sir {array[i]}");
            }
        }
        
    }
}
