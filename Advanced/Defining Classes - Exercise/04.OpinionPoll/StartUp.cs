using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for (int i = 0; i < N; i++)
            {
                string[] personData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string personName = personData[0];
                int personAge = int.Parse(personData[1]);
                people.Add(new Person(personName, personAge));                
            }

            foreach (var person in people.Where(x=>x.Age>30).OrderBy(x=>x.Name))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
