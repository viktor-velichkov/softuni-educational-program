using System;
using System.Runtime.Loader;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _08.Threeuple
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] firstLine = Console.ReadLine().Split();
            string name = $"{firstLine[0]} {firstLine[1]}";
            string address = firstLine[2];
            StringBuilder town = new StringBuilder();
            for (int i = 3; i < firstLine.Length; i++)
            {
                town.Append($"{firstLine[i]} ");
            }
            Threeuple<string, string,string> personInfo = new Threeuple<string, string,string>(name, address,town.ToString().Trim());
            string[] secondline = Console.ReadLine().Split();
            int litresOfBeer = int.Parse(secondline[1]);
            Predicate<string> dreger = x => x == "drunk";
            bool isDrunk = dreger(secondline[2]);
            Threeuple<string, int,bool> drunkInfo = new Threeuple<string, int,bool>(secondline[0], litresOfBeer,isDrunk);
            string[] thirdLine = Console.ReadLine().Split();
            double balance = double.Parse(thirdLine[1]);
            string bank = thirdLine[2];
            Threeuple<string, double,string> bankAccInfo = new Threeuple<string, double,string>(thirdLine[0], balance,bank);
            Console.WriteLine(personInfo);
            Console.WriteLine(drunkInfo);
            Console.WriteLine(bankAccInfo);
        }
    }
}
