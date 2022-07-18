using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace _08.CarSalesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < N; i++)
            {
                string[] engineData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = engineData[0];
                int power = int.Parse(engineData[1]);
                int displacement = 0;
                string efficiency = "";
                if (engineData.Length > 3)
                {
                    displacement = int.Parse(engineData[2]);
                    efficiency = engineData[3];
                    engines.Add(new Engine(model, power, displacement, efficiency));
                }
                if (engineData.Length > 2)
                {
                    int number;
                    if (Int32.TryParse(engineData[2], out number))
                    {
                        displacement = number;
                        engines.Add(new Engine(model, power, displacement));
                    }
                    else
                    {
                        efficiency = engineData[2];
                        engines.Add(new Engine(model, power, efficiency));
                    }                  
                }
                else
                {
                    engines.Add(new Engine(model, power));
                }
            }
            int M = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < M; i++)
            {
                string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = carData[0];
                Engine engine = engines.Find(x => x.Model == carData[1]);
                int weight = 0;
                string color = "";
                if (carData.Length > 3)
                {
                    weight = int.Parse(carData[2]);
                    color = carData[3];
                    cars.Add(new Car(model, engine, weight, color));
                }
                else if (carData.Length > 2)
                {
                    int number;
                    if (Int32.TryParse(carData[2], out number))
                    {
                        weight = number;
                        cars.Add(new Car(model, engine, weight));
                    }
                    else
                    {
                        color = carData[2];
                        cars.Add(new Car(model, engine, color));
                    }
                }
                else
                {
                    cars.Add(new Car(model, engine));
                }
            }
            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
