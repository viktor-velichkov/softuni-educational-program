using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using WildFarm.Core.Contracts;
using WildFarm.Exceptions;
using WildFarm.Factories;
using WildFarm.IO.Contracts;
using WildFarm.Models;
using WildFarm.Models.Contracts;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly AnimalFactory animalFactory;
        private readonly FoodFactory foodFactory;
        private ICollection<IAnimal> animals;
        public Engine(IReader reader, IWriter writer, AnimalFactory animalFactory, FoodFactory foodFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
            this.animals = new List<IAnimal>();

        }
        public void Run()
        {
            string command;
            int lineCounter = 0;
            while ((command = this.reader.ReadLine()) != "End")
            {
                if (lineCounter % 2 == 0)
                {
                    string[] animalArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    this.animals.Add(CreateAnimal(animalArgs));
                }
                else
                {
                    string[] foodArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    IFood currentFood = foodFactory.CreateFood(foodArgs);
                    try
                    {
                        this.writer.WriteLine(this.animals.Last().AskForFood());
                        this.animals.Last().Eat(currentFood);
                    }
                    catch (WrongFoodTypeException e)
                    {
                        this.writer.WriteLine(e.Message);
                    }
                }
                lineCounter++;
            }
            foreach (var animal in this.animals)
            {
                this.writer.WriteLine(animal.ToString());
            }
        }
        public IAnimal CreateAnimal(string[] data)
        {
            string animalType = data[0];
            string name = data[1];
            double weight = double.Parse(data[2]);
            double wingSize;
            string region;
            string breed;

            IAnimal animal = null;
            if (Assembly.GetAssembly(typeof(Mammal)).GetTypes().Where(x => typeof(Mammal).IsAssignableFrom(x)).Select(x => x.Name).Contains(animalType))
            {
                region = data[3];
                if (data.Length > 4)
                {
                    breed = data[4];
                }
                else
                {
                    breed = "";
                }
                animal = animalFactory.CreateMammal(animalType, name, weight, region, breed);
            }
            else if (Assembly.GetAssembly(typeof(Bird)).GetTypes().Where(x => typeof(Bird).IsAssignableFrom(x)).Select(x => x.Name).Contains(animalType))
            {
                wingSize = double.Parse(data[3]);
                animal = animalFactory.CreateBird(animalType, name, weight, wingSize);
            }
            return animal;
        }
    }
}
