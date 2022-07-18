using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    class Parking
    {
        private Dictionary<string, Car> cars;
        private int capacity;
        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new Dictionary<string, Car>();
        }
        public int Count
        {
            get
            {
                return this.cars.Count;
            }
        }
        public string AddCar(Car car)
        {
            if (this.cars.ContainsKey(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (this.cars.Count == this.capacity)
            {
                return "Parking is full!";
            }
            else
            {
                this.cars.Add(car.RegistrationNumber, car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }
        public string RemoveCar(string registrationNumber)
        {
            if (!this.cars.ContainsKey(registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                this.cars.Remove(registrationNumber);
                return $"Successfully removed {registrationNumber}";
            }
        }
        public Car GetCar(string registrationNumber)
        {
            return this.cars[registrationNumber];
        }
        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var number in registrationNumbers)
            {
                if (this.cars.ContainsKey(number))
                {
                    this.cars.Remove(number);
                }
            }
        }
    }
}
