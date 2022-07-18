using _06.SpeedRacing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < N; i++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string model = data[0];
                int engineSpeed = int.Parse(data[1]);
                int enginePower = int.Parse(data[2]);
                int cargoWeight = int.Parse(data[3]);
                string cargoType = data[4];
                Tire[] tires = new Tire[4];
                for (int j = 5; j < 13; j+=2)
                {
                    tires[(j-5)/2] = new Tire(int.Parse(data[j+1]), double.Parse(data[j]));
                }
                cars.Add(new Car(model, new Engine(engineSpeed, enginePower), new Cargo(cargoType, cargoWeight), tires));
            }
            string filter = Console.ReadLine();
            if (filter=="fragile")
            {
                foreach (var car in cars.Where(x=> x.Cargo.Type==filter&&x.Tires.Select(x=>x.Pressure).Min()<1))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (filter =="flamable")
            {
                foreach (var car in cars.Where(x => x.Cargo.Type == filter && x.Engine.Power>250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
