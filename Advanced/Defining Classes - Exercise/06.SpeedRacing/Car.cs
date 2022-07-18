using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace _06.SpeedRacing
{
    class Car
    {
        public Car(string model,double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumption;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive(double distance)
        {
            double consumption = this.FuelConsumptionPerKilometer * distance;
            if (this.FuelAmount>=consumption)
            {
                this.FuelAmount -= consumption;
                this.TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

    }
}
