using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace _07._TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>[]> vloggers = new Dictionary<string, HashSet<string>[]>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input != "Statistics")
                {
                    string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string vloggerName = command[0];
                    switch (command[1])
                    {
                        case "joined":
                            if (!vloggers.ContainsKey(vloggerName))
                            {
                                vloggers.Add(vloggerName, new HashSet<string>[2] { new HashSet<string>(), new HashSet<string>() });

                            }
                            break;
                        case "followed":
                            string followedVlogger = command[2];
                            if (vloggers.ContainsKey(vloggerName) && vloggers.ContainsKey(followedVlogger) && vloggerName != followedVlogger)
                            {
                                var asd = vloggers[followedVlogger][0].Add(vloggerName);
                                vloggers[vloggerName][1].Add(followedVlogger);
                            }
                            break;
                    }
                }

                else
                {
                    break;
                }
            }
            var sortedVloggers = vloggers.OrderByDescending(x => x.Value[0].Count).ThenBy(x => x.Value[1].Count).ToArray();
            Console.WriteLine($"The V-Logger has a total of {sortedVloggers.Length} vloggers in its logs.");
            Console.WriteLine($"1. {sortedVloggers[0].Key} : {sortedVloggers[0].Value[0].Count} followers, {sortedVloggers[0].Value[1].Count} following");
            foreach (var follower in sortedVloggers[0].Value[0].OrderBy(x=>x))
            {
                Console.WriteLine($"*  {follower}");
            }
            for (int i = 1; i < sortedVloggers.Length; i++)
            {
                Console.WriteLine($"{i+1}. {sortedVloggers[i].Key} : {sortedVloggers[i].Value[0].Count} followers, {sortedVloggers[i].Value[1].Count} following");
            }

        }
    }
}
