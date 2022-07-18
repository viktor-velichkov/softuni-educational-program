using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._ThePartyReservationFilterModule
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> invitations = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> filters = new List<string>();
            Action<List<string>> print = PrintInvitations;
            while (true)
            {
                string input = Console.ReadLine();
                if (input != "Print")
                {
                    if (input.StartsWith("Add filter;"))
                    {
                        filters.Add(input.Substring(11));
                    }
                    else if (input.StartsWith("Remove filter;"))
                    {
                        filters.Remove(input.Substring(14));
                    }
                }
                else
                {
                    foreach (var filter in filters)
                    {
                        Action<List<string>> addFilter = AddFilter(filter);
                        addFilter(invitations);
                    }
                    break;
                }
            }
            print(invitations);
        }
        static Func<string, bool> Filter(string filterType, string condition)
        {
            switch (filterType)
            {
                case "Starts with":
                    return x => x.StartsWith(condition);
                case "Ends with":
                    return x => x.EndsWith(condition);
                case "Length":
                    return x => x.Length == int.Parse(condition);
                case "Contains":
                    return x => x.Contains(condition);
                default:
                    return null;
            }
        }
        static Action<List<string>> AddFilter(string command)
        {
            string[] commandTokens = command.Split(";").ToArray();
            string filterType = commandTokens[0];
            string condition = commandTokens[1];
            Func<string, bool> filter = Filter(filterType, condition);
            return x =>
            {
                for (int i = 0; i < x.Count; i++)
                {
                    if (filter(x[i]))
                    {
                        x.RemoveAt(i--);
                    }
                }
            };
        }
        static void PrintInvitations(List<string> list)
        {
            Console.WriteLine(String.Join(" ",list));
        }
    }
}
