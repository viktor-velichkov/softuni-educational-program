using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, double>> shops = new SortedDictionary<string, Dictionary<string, double>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input!="Revision")
                {
                    string[] data = input.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string shop = data[0];
                    string product = data[1];
                    double price = double.Parse(data[2]);
                    if (!shops.ContainsKey(shop))
                    {
                        shops.Add(shop, new Dictionary<string, double>());
                    }
                    if (!shops[shop].ContainsKey(product))
                    {
                        shops[shop].Add(product, price);
                    }
                    shops[shop][product] = price;
                }
                else
                {
                    foreach (var shop in shops)
                    {
                        Console.WriteLine($"{shop.Key}->");
                        foreach (var product in shop.Value)
                        {
                            Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                        }
                    }
                    break;
                }
            }
        }
    }
}
