using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../Input.txt"))
            {
                string line = reader.ReadLine();
                using (var writer = new StreamWriter("../../../Output.txt"))
                {
                    int i = 0;
                    while (line != null)
                    {
                        writer.WriteLine($"{i + 1}. {line}");
                        i++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
