using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _04._AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] prices = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            Func<double[],double[]> addVAT = AddVAT;
            Action<double[]> print = PrintPrices;
            print(addVAT(prices));
            

        }
        static double[] AddVAT(double[] prices)
        {
            for (int i = 0; i < prices.Length; i++)
            {
                prices[i] *= 1.2;
            }
            return prices;
        }
        static void PrintPrices(double[] prices)
        {
            foreach (var price in prices)
            {
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
