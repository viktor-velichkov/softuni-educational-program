using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        int age;
        public Animal(string name, int age, string gender)
        {
            this.Age = age;
            this.Name = name;
            this.Gender = gender;
        }
        public string Name { get; set; }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }
        public string Gender { get; set; }
        public abstract string ProduceSound();
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"{this.GetType().Name}");
            result.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            result.AppendLine($"{this.ProduceSound()}");
            return result.ToString().Trim();
        }
    }
}
