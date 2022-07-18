using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _06.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < N; i++)
            {
                string[] carData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double fuelConsumption = double.Parse(carData[2]);
                cars.Add(new Car(model, fuelAmount, fuelConsumption));
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input != "End")
                {
                    string[] action = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string carModel = action[1];
                    double distance = double.Parse(action[2]);
                    cars.Find(x => x.Model == carModel).Drive(distance);
                }
                else
                {
                    foreach (var car in cars)
                    {
                        Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
                    }
                    break;
                }
            }
        }
    }
}
