using System;
using System.IO;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../Input.txt"))
            {
                int index = 0;
                string currentLine = reader.ReadLine();
                using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
                {
                    while (currentLine != null)
                    {
                        if (index % 2 != 0)
                        {
                            writer.WriteLine(currentLine);
                        }
                        index++;
                        currentLine = reader.ReadLine();
                    }
                }
            }
        }
    }
}
