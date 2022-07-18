using _01.Vehicles.Exceptions;
using _01.Vehicles.Common;
using System;

namespace _01.Vehicles.Models
{
    public class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumptionPerKm;
        private double tankCapacity;


        public Vehicle(double fuel, double consumption, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuel;
            this.FuelConsumptionPerKm = consumption;

        }
        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            protected set
            {
                if (value > this.TankCapacity)
                {
                    return;
                }
                this.fuelQuantity = value;
            }
        }
        public double FuelConsumptionPerKm { get { return this.fuelConsumptionPerKm; } protected set { this.fuelConsumptionPerKm = value; } }
        public double TankCapacity { get { return this.tankCapacity; } protected set { this.tankCapacity = value; } }

        public virtual string Drive(double distance)
        {
            if (this.FuelQuantity < distance * this.FuelConsumptionPerKm)
            {
                throw new NotEnoughFuelException(String.Format(GlobalConstants.UNSUCCESSFULL_DRIVE_MESSAGE, this.GetType().Name));
            }
            else
            {
                this.FuelQuantity -= distance * this.FuelConsumptionPerKm;
                return String.Format(GlobalConstants.SUCCESSFULL_DRIVE_MESSAGE, this.GetType().Name, distance);
            }

        }
        public virtual void Refuel(double fuelLitres)
        {
            if (fuelLitres <= 0)
            {
                throw new InvalidFuelAmountException(GlobalConstants.INVALID_FUEL_AMOUNT_EXCEPTION_MESSAGE);
            }
            if (this.FuelQuantity + fuelLitres > this.TankCapacity)
            {
                throw new OverfilledTankException(String.Format(GlobalConstants.OVERFILLED_TANK_EXCEPTION_MESSAGE, fuelLitres));
            }
            this.FuelQuantity += fuelLitres;
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
