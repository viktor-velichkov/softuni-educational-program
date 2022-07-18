using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._FilterByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Dictionary<string, int> people = new Dictionary<string, int>();
            for (int i = 0; i < N; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = input[0];
                int age = int.Parse(input[1]);
                people.Add(name, age);
            }
            string condition = Console.ReadLine();
            int ageFilter = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();
            Func<string, int, Func<KeyValuePair<string, int>, bool>> conditionFunction = ConditionFunction;
            Func<string, Func<KeyValuePair<string, int>, string>> printFormat = PrintFormat;
            var filteredPeople = people.Where(conditionFunction(condition, ageFilter)).ToArray();
            Action<string[]> print = PrintPeople;
            print(filteredPeople.Select(printFormat(format)).ToArray());
        }
        static Func<KeyValuePair<string, int>, bool> ConditionFunction(string condition, int age)
        {
            switch (condition)
            {
                case "younger":
                    return x => x.Value < age;

                case "older":
                    return x => x.Value >= age;
                default:
                    return null;

            }
        }
        static Func<KeyValuePair<string, int>, string> PrintFormat(string format)
        {
            switch (format)
            {
                case "name":
                    return x => x.Key;
                case "age":
                    return x => x.Value.ToString();
                case "name age":
                    return x => $"{x.Key} - {x.Value}";
                default:
                    return null;

            }
        }
        static void PrintPeople(string[] people)
        {
            foreach (var person in people)
            {
                Console.WriteLine(person);
            }
        }

    }
}
