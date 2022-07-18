using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            person.Name = "Viktor";
            person.Age = 30;

            Person pesho = new Person("Pesho", 20);
            Person gosho = new Person("Gosho", 18);
            Person stamat = new Person("Stamat", 43);


        }
    }
}
