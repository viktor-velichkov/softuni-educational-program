using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            
            while (true)
            {
                string input = Console.ReadLine();
                if (input != "No more tires")
                {
                    string[] tiresData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    int[] tiresYears = GetEvenOrOddPositions(tiresData, 0).Select(x => int.Parse(x)).ToArray();
                    double[] tiresPressure = GetEvenOrOddPositions(tiresData, 1).Select(x => double.Parse(x)).ToArray();
                    Tire[] newTires = new Tire[4];
                    for (int i = 0; i < newTires.Length; i++)
                    {
                        newTires[i] = new Tire(tiresYears[i], tiresPressure[i]);
                    }
                    tires.Add(newTires);
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input != "Engines done")
                {
                    string[] engineData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    int enginePower = int.Parse(engineData[0]);
                    double engineCapacity = double.Parse(engineData[1]);
                    engines.Add(new Engine(enginePower, engineCapacity));
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input != "Show special")
                {
                    string[] carData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string make = carData[0];
                    string model = carData[1];
                    int year = int.Parse(carData[2]);
                    double fuelQuantity = double.Parse(carData[3]);
                    double fuelConsumption = double.Parse(carData[4]);
                    int engineIndex = int.Parse(carData[5]);
                    int tiresIndex = int.Parse(carData[6]);
                    cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]));
                }
                else
                {
                    var specialCars = cars.Where(x => x.Year >= 2017
                                                   && x.Engine.HorsePower > 330
                                                   && x.Tires.Select(x => x.Pressure).Sum() > 9
                                                   && x.Tires.Select(x => x.Pressure).Sum() < 10)
                                                   .ToArray();
                    foreach (var car in specialCars)
                    {
                        car.Drive(20);
                        Console.WriteLine(car.PrintSpecialCar());
                    }
                    break;
                }
            }
            
        }
        static string[] GetEvenOrOddPositions(string[] array, int choice)
        {
            List<string> result = new List<string>();
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 == choice)
                {
                    result.Add(array[i]);
                }
            }
            return result.ToArray();
        }

    }
}
