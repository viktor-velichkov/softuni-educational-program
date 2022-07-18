using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles.Models
{
    public class Bus : Vehicle
    {
        
        public Bus(double fuel, double consumption, double tankCapacity) : base(fuel, consumption, tankCapacity)
        {
            this.FuelConsumptionPerKm += 1.4;
        }
        public string DriveEmpty(double distance)
        {
            this.FuelConsumptionPerKm -= 1.4;
            return this.Drive(distance);
        }
    }
}
