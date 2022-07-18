using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Family newFamily = new Family();
            
            for (int i = 0; i < N; i++)
            {
                string[] personData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string personName = personData[0];
                int personAge = int.Parse(personData[1]);
                newFamily.AddMember(new Person(personName, personAge));                
            }
            Person oldestMember = newFamily.GetOldestMember();
            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
}
