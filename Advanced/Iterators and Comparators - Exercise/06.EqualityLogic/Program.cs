using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.EqualityLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<Person> hashPeople = new HashSet<Person>();
            SortedSet<Person> sortedPeople = new SortedSet<Person>();
            for (int i = 0; i < n; i++)
            {
                string[] personData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = personData[0];
                int age = int.Parse(personData[1]);
                Person currentPerson = new Person(name, age);
                hashPeople.Add(currentPerson);
                sortedPeople.Add(currentPerson);
            }
            Console.WriteLine(sortedPeople.Count);
            Console.WriteLine(hashPeople.Count);
        }
    }
}
