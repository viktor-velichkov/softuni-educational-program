using System;
using System.Collections.Generic;

namespace _06.GenericCountMethodDouble
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<double>();
            for (int i = 0; i < n; i++)
            {
                list.Add(double.Parse(Console.ReadLine()));
            }
            double element = double.Parse(Console.ReadLine());
            var box = new Box<double>(list);
            Console.WriteLine(box.CountOfElementInlist(element));
        }
    }
}
