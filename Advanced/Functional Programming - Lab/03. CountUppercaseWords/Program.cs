using System;
using System.Linq;

namespace _03._CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Func<string, bool> checker = IsStartingWithCapital;
            Action<string[]> print = Printer;
            print(words.Where(x => checker(x)).ToArray());
        }
        static bool IsStartingWithCapital(string word)
        {
            if (word[0]==word.ToUpper()[0])
            {
                return true;
            }
            return false;
        }
        static void Printer(string[] words)
        {
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
