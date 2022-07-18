using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._PredicateParty_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> invitedPeople = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            Action<List<string>> print = PrintGuests;
            while (true)
            {
                string input = Console.ReadLine();
                if (input != "Party!")
                {
                    string[] command = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string action = command[0];
                    string filter = command[1];
                    string condition = command[2];
                    Func<string, bool> filterDelegate = Filter(filter, condition);
                    for (int i = 0; i < invitedPeople.Count; i++)
                    {
                        Action<List<string>> modify = DoubleOrRemovePerson(action, invitedPeople[i]);
                        if (filterDelegate(invitedPeople[i]))
                        {
                            modify(invitedPeople);
                            if (action == "Remove")
                            {
                                i--;
                            }
                            else if (action == "Double")
                            {
                                i++;
                            }
                        }

                    }
                }
                else
                {
                    print(invitedPeople);
                    break;
                }
            }
            

        }
        static Func<string, bool> Filter(string filter, string condition)
        {
            switch (filter)
            {
                case "StartsWith":
                    return x => x.StartsWith(condition);
                case "EndsWith":
                    return x => x.EndsWith(condition);
                case "Length":
                    return x => x.Length == int.Parse(condition);
                default:
                    return null;
            }
        }
        static Action<List<string>> DoubleOrRemovePerson(string action, string person)
        {
            switch (action)
            {
                case "Remove":
                    return x => x.Remove(person);
                case "Double":
                    return x => x.Insert(x.IndexOf(person) + 1, person);
                default:
                    return null;
            }
        }
        static void PrintGuests(List<string> guests)
        {
            if (guests.Count != 0)
            {
                Console.WriteLine($"{String.Join(", ", guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

    }
}
