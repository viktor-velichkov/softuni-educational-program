using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodString
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<string>();
            for (int i = 0; i < n; i++)
            {
                list.Add(Console.ReadLine());
            }
            string element = Console.ReadLine();
            var box = new Box<string>(list);
            Console.WriteLine(box.CountOfElementInlist(element));
        }
    }
}
