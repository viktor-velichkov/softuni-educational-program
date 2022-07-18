using System;
using System.IO;
using System.Linq;
using System.Text;

namespace _01._EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] symbolsToReplace = new char[] { '-', ',', '.', '!', '?' };
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                string line = reader.ReadLine();
                int index = 0;
                while (line != null)
                {
                    if (index % 2 == 0)
                    {
                        string[] reversedLine = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray().Reverse().ToArray();
                        StringBuilder linee = new StringBuilder().Append(String.Join(" ", reversedLine));
                        foreach (var symbol in symbolsToReplace)
                        {
                            linee.Replace(symbol, '@');
                        }
                        Console.WriteLine(linee.ToString());
                    }
                    line = reader.ReadLine();
                    index++;
                }
            }
        }
    }
}
