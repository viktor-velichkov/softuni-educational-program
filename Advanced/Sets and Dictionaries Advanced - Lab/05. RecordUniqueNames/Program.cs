using System;
using System.Collections.Generic;

namespace _05._RecordUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputsCount = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();
            for (int i = 0; i < inputsCount; i++)
            {
                names.Add(Console.ReadLine());
            }
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
