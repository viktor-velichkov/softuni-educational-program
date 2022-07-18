using System;
using System.Linq;

namespace _05._AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] array = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            while (true)
            {
                string input = Console.ReadLine();
                if (input != "end")
                {
                    Action<int[]> actionDelegate = ApplyAction(input);
                    actionDelegate(array);
                }
                else
                {
                    break;
                }
            }
        }
        static Action<int[]> ApplyAction(string action)
        {
            Action<int[]> print = PrintArray;
            switch (action)
            {
                case "add":
                    return x =>
                    {
                        for (int i = 0; i < x.Length; i++)
                        {
                            x[i] += 1;
                        }
                    };
                case "multiply":
                    return x =>
                    {
                        for (int i = 0; i < x.Length; i++)
                        {
                            x[i] *= 2;
                        }
                    };
                case "subtract":
                    return x =>
                    {
                        for (int i = 0; i < x.Length; i++)
                        {
                            x[i] -= 1;
                        }
                    };
                case "print":
                    return x => print(x);
                default:
                    return null;
            }
        }
        static void PrintArray(int[] array)
        {
            Console.WriteLine(String.Join(" ", array));
        }
    }
}
