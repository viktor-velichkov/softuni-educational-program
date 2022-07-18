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
            HashSet<string> wordsToFind = new HashSet<string>();
            using (StreamReader reader = new StreamReader("../../../words.txt"))
            {
                string[] line = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                foreach (var word in line)
                {
                    wordsToFind.Add(word);
                }
            }
            
            string text = "";
            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                text = reader.ReadToEnd();
            }
            foreach (var word in wordsToFind)
            {                
                Regex pattern = new Regex($@"(?i:\b{word}\b)");
                int matchesCount = pattern.Matches(text).Count;
                dictionary.Add(word, matchesCount);
            }
            using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
            {
                foreach (var pair in dictionary.OrderByDescending(x=>x.Value))
                {
                    writer.WriteLine($"{pair.Key} - {pair.Value}");
                }
            }


        }
    }
}
