using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Parking
{
    public class Parking
    {
        Dictionary<int, Car> cars = new Dictionary<int, Car>();
        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
        }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.cars.Count; } }

        public void Add(Car car)
        {
            if (!cars.ContainsKey(car.Year) && this.Count < this.Capacity)
            {
                this.cars.Add(car.Year, car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            try
            {
                return cars.Remove(cars.Where(x => x.Value.Manufacturer == manufacturer && x.Value.Model == model).Select(x => x.Key).ToArray()[0]);
            }
            catch (IndexOutOfRangeException)
            {
                return false;
            }

        }
        public Car GetLatestCar()
        {
            if (cars.Count != 0)
            {
                return cars[cars.Keys.ToArray().Max()];
            }
            else
            {
                return null;
            }
        }
        public Car GetCar(string manufacturer, string model)
        {
            try
            {
                return cars.Where(x => x.Value.Manufacturer == manufacturer && x.Value.Model == model).Select(x => x.Value).ToArray()[0];
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }
        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"The cars are parked in {this.Type}:");
            foreach (var car in cars.Values)
            {
                result.AppendLine(car.ToString());
            }
            return result.ToString().Trim();
        }
    }
}
