using _05.BirthdayCelebrations.Contracts;
using _05.BirthdayCelebrations.Exceptions;
using _05.BirthdayCelebrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BirthdayCelebrations.Core
{
    public class Engine
    {
        public void Run()
        {
            string input;
            List<IBeing> beings = new List<IBeing>();
            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] objectData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string objectType = objectData[0];
                    switch (objectType)
                    {
                        case "Citizen":
                            string citizenName = objectData[1];
                            int citizenAge = int.Parse(objectData[2]);
                            string citizenId = objectData[3];
                            string citizenBirthdate = objectData[4];
                            beings.Add(new Citizen(citizenName, citizenAge, citizenId, citizenBirthdate));
                            break;
                        case "Pet":
                            string petName = objectData[1];
                            string petBirthdate = objectData[2];
                            beings.Add(new Pet(petName, petBirthdate));
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

            string birthdayYear = Console.ReadLine();
            foreach (var being in beings.Where(x => x.Birthdate.EndsWith($"/{birthdayYear}")))
            {
                Console.WriteLine(being.Birthdate);
            }
        }
    }
}
