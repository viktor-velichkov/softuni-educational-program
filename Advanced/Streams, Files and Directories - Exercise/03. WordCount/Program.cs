using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03._WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            string[] wordsToFind = File.ReadAllLines("../../../words.txt");
            string text = File.ReadAllText("../../../text.txt");
            foreach (var word in wordsToFind)
            {
                Regex pattern = new Regex($@"(?i:\b{word}\b)");
                int matchesCount = pattern.Matches(text).Count;
                dictionary.Add(word, matchesCount);
            }
            List<string> result = new List<string>();
            foreach (var pair in dictionary.OrderByDescending(x => x.Value))
            {
                result.Add($"{pair.Key} - {pair.Value}");
            }
            File.WriteAllLines("../../../actualResult.txt", result);
            
            if (File.ReadAllText("../../../actualResult.txt") == File.ReadAllText("../../../expectedResult.txt"))
            {
                Console.WriteLine(true);
            }
            else
            {
                Console.WriteLine(false);
            }
        }
    }
}
