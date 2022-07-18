using System;
using System.Linq;
using System.Reflection;
using WildFarm.Models;
using WildFarm.Models.Contracts;

namespace WildFarm.Factories
{
    public class AnimalFactory
    {
        public IAnimal CreateMammal(string mammalType, string name, double weight, string region, string breed)
        {
            if (Assembly.GetAssembly(typeof(Feline)).GetTypes().Where(x => typeof(Feline).IsAssignableFrom(x)).Select(x => x.Name).Contains(mammalType))
            {
                return CreateFeline(mammalType, name, weight, region, breed);
            }
            else if (mammalType == nameof(Mouse))
            {
                return CreateMouse(name, weight, region);
            }
            else if (mammalType == nameof(Dog))
            {
                return CreateDog(name, weight, region);
            }
            else
            {
                return null;
            }

        }
        private IAnimal CreateFeline(string felineType, string name, double weight, string region, string breed)
        {
            if (felineType == nameof(Cat))
            {
                return new Cat(name, weight, region, breed);
            }
            else if (felineType == nameof(Tiger))
            {
                return new Tiger(name, weight, region, breed);
            }
            else
            {
                return null;
            }
        }
        private IAnimal CreateMouse(string name, double weight, string region)
        {
            return new Mouse(name, weight, region);
        }
        private IAnimal CreateDog(string name, double weight, string region)
        {
            return new Dog(name, weight, region);
        }
        public IAnimal CreateBird(string birdType, string name, double weight, double wingSize)
        {
            if (birdType == nameof(Owl))
            {
                return new Owl(name, weight, wingSize);
            }
            else if (birdType == nameof(Hen))
            {
                return new Hen(name, weight, wingSize);
            }
            else
            {
                return null;
            }
        }
    }
}
