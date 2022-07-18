using _03.Telephony.Exceptions;
using _03.Telephony.Models;
using System;
using System.Linq;

namespace _03.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            StationaryPhone phone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();
            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (var number in numbers)
            {
                try
                {
                    if (number.Length == 7)
                    {
                        Console.WriteLine(phone.Call(number));
                    }
                    else if (number.Length == 10)
                    {
                        Console.WriteLine(smartphone.Call(number));
                    }
                    else
                    {
                        throw new InvalidNumberException();
                    }
                }
                catch (InvalidNumberException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine(smartphone.Browse(url));
                }
                catch (InvalidURLException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
