using System;
using System.IO;
using System.Text.RegularExpressions;

namespace _02._LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex letters = new Regex(@"\w");
            Regex punctioationMarks = new Regex("[,.?;!:'()[\\]\"\\-\\/@{}*]");
            string[] linesToRead = File.ReadAllLines("../../../text.txt");
            string[] linesToWrite = new string[linesToRead.Length];
            for (int i = 0; i < linesToRead.Length; i++)
            {
                linesToWrite[i] = $"Line {i + 1}: {linesToRead[i]} ({letters.Matches(linesToRead[i]).Count})({punctioationMarks.Matches(linesToRead[i]).Count})";
            }
            File.WriteAllLines("../../../Output.txt", linesToWrite);
        }
    }
}
