using _09.ExplicitInterfaces.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace _09.ExplicitInterfaces.Models
{
    public class Citizen : IPerson, IResident
    {
        string name;
        int age;
        string country;
        public Citizen(string name, int age, string country)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }
        public string Name { get { return this.name; } set { this.name = value; } }
        public int Age { get { return this.age; } set { this.age = value; } }
        public string Country { get { return this.country; } set { this.country = value; } }

        string IPerson.GetName()
        {
            return this.Name;
        }
        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }
    }
}
