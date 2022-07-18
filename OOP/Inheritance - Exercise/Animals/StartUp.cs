using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string typeOfAnimal = Console.ReadLine();

                if (typeOfAnimal == "Beast!")
                {
                    break;
                }

                string[] animalInfo = Console.ReadLine()
                    .Split()
                    .ToArray();

                if (animalInfo.Length >= 3)
                {
                    Animal animal;

                    string name = animalInfo[0];
                    int age = int.Parse(animalInfo[1]);
                    string gender = animalInfo[2];

                    if (age <= 0)
                    {
                        throw new ArgumentException("Invalid input!");
                    }

                    switch (typeOfAnimal)
                    {
                        case "Dog":
                            animal = new Dog(name, age, gender);
                            break;

                        case "Frog":
                            animal = new Frog(name, age, gender);
                            break;

                        case "Cat":
                            animal = new Cat(name, age, gender);
                            break;

                        case "Kitten":
                            animal = new Kitten(name, age);
                            break;

                        case "Tomcat":
                            animal = new Tomcat(name, age);
                            break;

                        default:
                            throw new ArgumentException("Invalid input!");
                    }

                    animals.Add(animal);
                }

                else
                {
                    throw new ArgumentException("Invalid input!");
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}

