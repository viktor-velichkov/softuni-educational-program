using System;

namespace _05._DateModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();
            Console.WriteLine(DateModifier.CalculateDaysDifference(firstDate, secondDate));
        }
    }
}
