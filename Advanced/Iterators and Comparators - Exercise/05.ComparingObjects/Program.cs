using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ComparingObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input!="END")
                {
                    string[] personData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string name = personData[0];
                    int age = int.Parse(personData[1]);
                    string town = personData[2];
                    people.Add(new Person(name, age, town));
                }
                else
                {
                    break;
                }
            }
            int index = int.Parse(Console.ReadLine()) - 1;
            Person personToCheck = people[index];
            int equalPeople = 0;
            int differentPeople = 0;
            foreach (var person in people)
            {
                if (personToCheck.CompareTo(person)==0)
                {
                    equalPeople++;
                }
                else
                {
                    differentPeople++;
                }
            }
            if (equalPeople==0||equalPeople==1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalPeople} {differentPeople} {people.Count}");
            }
            
        }
    }
}
