using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int petrolStationsCount = int.Parse(Console.ReadLine());
            Queue<string> pumpStationsInfo = new Queue<string>();
            for (int i = 0; i < petrolStationsCount; i++)
            {
                string input = Console.ReadLine();
                input += $" {i}";
                pumpStationsInfo.Enqueue(input);
            }
            int fuel = 0;
            for (int i = 0; i < petrolStationsCount; i++)
            {
                string currentInfo = pumpStationsInfo.Dequeue();
                var info = currentInfo.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int fuelCharge = info[0];
                int fuelNeed = info[1];
                fuel += fuelCharge;
                if (fuel >= fuelNeed)
                {
                    fuel -= fuelNeed;
                }
                else
                {
                    fuel = 0;
                    i=-1;
                }
                pumpStationsInfo.Enqueue(currentInfo);
            }
            string[] startingPumpStation = pumpStationsInfo.Dequeue().Split(" ",StringSplitOptions.RemoveEmptyEntries).ToArray();
            Console.WriteLine(startingPumpStation[2]);
        }
    }
}
