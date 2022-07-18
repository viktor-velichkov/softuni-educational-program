using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> results = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input != "end of contests")
                {
                    string[] contestData = input.Split(":", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string contestName = contestData[0];
                    string contestPass = contestData[1];
                    if (!contests.ContainsKey(contestName))
                    {
                        contests.Add(contestName, "");
                    }
                    contests[contestName] = contestPass;
                }
                else
                {
                    break;
                }

            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input != "end of submissions")
                {
                    string[] submission = input.Split("=>", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string contestName = submission[0];
                    string contestPass = submission[1];
                    string userName = submission[2];
                    int points = int.Parse(submission[3]);
                    if (contests.ContainsKey(contestName) && contests[contestName] == contestPass)
                    {
                        if (!results.ContainsKey(userName))
                        {
                            results.Add(userName, new Dictionary<string, int>());
                            results[userName].Add(contestName, int.MinValue);
                        }
                        if (!results[userName].ContainsKey(contestName))
                        {
                            results[userName].Add(contestName, points);
                        }
                        else
                        {
                            if (results[userName][contestName] < points)
                            {
                                results[userName][contestName] = points;
                            }
                        }
                    }
                }
                else
                {
                    break;
                }

            }
            
            int maxPoints = int.MinValue;
            string bestCandidate = "";
            foreach (var user in results)
            {
                int currentSum = user.Value.Values.Sum();
                if (currentSum>maxPoints)
                {
                    maxPoints = currentSum;
                    bestCandidate = user.Key;
                }
            }
            Console.WriteLine($"Best candidate is {bestCandidate} with total {maxPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in results)
            {
                Console.WriteLine(user.Key);
                foreach (var contest in user.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
