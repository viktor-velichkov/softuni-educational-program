using _06.FoodShortage.Contracts;
using _06.FoodShortage.Exceptions;
using _06.FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FoodShortage.Core
{
    public class Engine
    {
        public void Run()
        {
            string input;
            List<IBuyer> buyers = new List<IBuyer>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                try
                {
                    string[] objectData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    switch (objectData.Length)
                    {
                        case 4:
                            string citizenName = objectData[0];
                            int citizenAge = int.Parse(objectData[1]);
                            string citizenId = objectData[2];
                            string citizenBirthdate = objectData[3];
                            buyers.Add(new Citizen(citizenName, citizenAge, citizenId, citizenBirthdate));
                            break;
                        case 3:
                            string rebelName = objectData[0];
                            int rebelAge = int.Parse(objectData[1]);
                            string rebelGroup = objectData[2];
                            buyers.Add(new Rebel(rebelName, rebelAge, rebelGroup));
                            break;
                        default:
                            throw new InvalidInputException();
                    }
                }
                catch (InvalidInputException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            while ((input = Console.ReadLine()) != "End")
            {
                var currentBuyer = buyers.Find(x => x.Name == input);
                if (currentBuyer != null)
                {
                    currentBuyer.BuyFood();
                }
            }
            Console.WriteLine(buyers.Select(x=>x.Food).Sum());

        }
    }
}
