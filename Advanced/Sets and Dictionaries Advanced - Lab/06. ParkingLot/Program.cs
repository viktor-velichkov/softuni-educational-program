using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input != "END")
                {
                    string[] action = input.Split(", ").ToArray();
                    string direction = action[0];
                    string carNumber = action[1];
                    if (direction == "IN")
                    {
                        parking.Add(carNumber);
                    }
                    else if (direction == "OUT" && parking.Contains(carNumber))
                    {
                        parking.Remove(carNumber);
                    }
                }
                else
                {
                    if (parking.Count>0)
                    {
                        foreach (var car in parking)
                        {
                            Console.WriteLine(car);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Parking Lot is Empty");
                    }
                    break;
                }
            }
        }
    }
}
