using System;
using System.Collections.Generic;

namespace _05._CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();
            for (int i = 0; i < text.Length; i++)
            {
                if (!symbols.ContainsKey(text[i]))
                {
                    symbols.Add(text[i], 0);
                }
                symbols[text[i]]++;
            }
            foreach (var symbol in symbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
