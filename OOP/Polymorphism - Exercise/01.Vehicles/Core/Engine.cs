using _01.Vehicles.Models;
using System;
using System.Collections.Generic;

namespace _01.Vehicles.Core
{
    public class Engine
    {
        public void Run()
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            for (int i = 0; i < 3; i++)
            {
                string[] vehicleData = Console.ReadLine().Split();
                string vehicleType = vehicleData[0];
                double vehicleFuel = double.Parse(vehicleData[1]);
                double vehicleFuelConsumption = double.Parse(vehicleData[2]);
                double vehicleTankCapacity = double.Parse(vehicleData[3]);

                switch (vehicleType)
                {
                    case "Car":
                        vehicles.Add(new Car(vehicleFuel, vehicleFuelConsumption, vehicleTankCapacity));
                        break;
                    case "Truck":
                        vehicles.Add(new Truck(vehicleFuel, vehicleFuelConsumption, vehicleTankCapacity));
                        break;
                    case "Bus":
                        vehicles.Add(new Bus(vehicleFuel, vehicleFuelConsumption, vehicleTankCapacity));
                        break;
                    default:
                        break;
                }
            }

            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                try
                {
                    string[] command = Console.ReadLine().Split();
                    string action = command[0];
                    string type = command[1];
                    Vehicle currentVehicle = vehicles.Find(x => x.GetType().Name == type);
                    switch (action)
                    {
                        case "Drive":
                            double distance = double.Parse(command[2]);
                            Console.WriteLine(currentVehicle.Drive(distance));
                            break;
                        case "Refuel":
                            double litres = double.Parse(command[2]);
                            currentVehicle.Refuel(litres);
                            break;
                        case "DriveEmpty":
                            if (currentVehicle is Bus bus)
                            {
                                Console.WriteLine(bus.DriveEmpty(double.Parse(command[2])));
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}
