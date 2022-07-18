using _04.BorderControl.Contracts;
using _04.BorderControl.Exceptions;
using _04.BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.BorderControl.Core
{
    public class Engine
    {
        public void Run()
        {
            string input;
            List<IVisitor> visitors = new List<IVisitor>();
            while ((input = Console.ReadLine()) != "End")
            {
                try
                {
                    string[] visitorData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    if (visitorData.Length == 3)
                    {
                        string name = visitorData[0];
                        int age = int.Parse(visitorData[1]);
                        string id = visitorData[2];
                        visitors.Add(new Citizen(name, age, id));
                    }
                    else if (visitorData.Length == 2)
                    {
                        string model = visitorData[0];
                        string robot_id = visitorData[1];
                        visitors.Add(new Robot(model, robot_id));
                    }
                    else
                    {
                        throw new InvalidInputException();
                    }
                }
                catch (InvalidInputException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            string invalidIdCode = Console.ReadLine();
            foreach (var visitor in visitors.Where(x => x.HasInvalidId(invalidIdCode)))
            {
                Console.WriteLine(visitor.Id);
            }
        }
    }
}
