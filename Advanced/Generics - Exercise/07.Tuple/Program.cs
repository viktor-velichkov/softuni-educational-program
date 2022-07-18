using System;
using System.Linq;

namespace _07.Tuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split();
            string name = $"{firstLine[0]} {firstLine[1]}";           
            Tuple<string, string> nameAndAdress = new Tuple<string, string>(name, firstLine[2]);
            string[] secondline = Console.ReadLine().Split();
            Tuple<string, int> nameAndLitres = new Tuple<string, int>(secondline[0], int.Parse(secondline[1]));
            string[] thirdLine = Console.ReadLine().Split();
            Tuple<int, double> intAndDouble = new Tuple<int, double>(int.Parse(thirdLine[0]), double.Parse(thirdLine[1]));
            Console.WriteLine(nameAndAdress);
            Console.WriteLine(nameAndLitres);
            Console.WriteLine(intAndDouble);
        }
    }
}
