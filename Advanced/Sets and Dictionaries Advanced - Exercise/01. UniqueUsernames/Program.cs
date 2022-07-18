using System;
using System.Collections.Generic;

namespace _01._UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> userNames = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                userNames.Add(Console.ReadLine());
            }
            foreach (var name in userNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
