using System;
using System.Collections.Generic;

namespace _07._SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> guests = new HashSet<string>();
            string input = Console.ReadLine();
            while (input!="PARTY")
            {
                if (char.IsDigit(input.ToCharArray()[0]))
                {
                    vipGuests.Add(input);
                }
                else
                {
                    guests.Add(input);
                }
                input = Console.ReadLine();
            }
            while (true)
            {
                input = Console.ReadLine();
                if (input!="END")
                {
                    if (char.IsDigit(input.ToCharArray()[0]))
                    {
                        if (vipGuests.Contains(input))
                        {
                            vipGuests.Remove(input);
                        }
                    }
                    else
                    {
                        if (guests.Contains(input))
                        {
                            guests.Remove(input);
                        }
                    }
                }
                else
                {
                    Console.WriteLine(vipGuests.Count+guests.Count);
                    foreach (var vip in vipGuests)
                    {
                        Console.WriteLine(vip);
                    }
                    foreach (var guest in guests)
                    {
                        Console.WriteLine(guest);
                    }
                    break;
                }
            }
        }
    }
}
