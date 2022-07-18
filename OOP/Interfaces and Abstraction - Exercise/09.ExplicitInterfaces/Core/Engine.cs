using _09.ExplicitInterfaces.Contracts;
using _09.ExplicitInterfaces.Models;
using System;

namespace _09.ExplicitInterfaces.Core
{
    public class Engine
    {
        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] data = input.Split();
                string name = data[0];
                string country = data[1];
                int age = int.Parse(data[2]);
                Citizen citizen = new Citizen(name, age, country);
                var person = citizen as IPerson;
                var resident = citizen as IResident;
                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName());
            }
        }
    }
}
