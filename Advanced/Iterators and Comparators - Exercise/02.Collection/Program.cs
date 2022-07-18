using System;
using System.Linq;
using System.Text;

namespace _02.Collection
{
    class Program
    {
        static void Main(string[] args)

        {
            var createData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
            createData.RemoveAt(0);
            ListyIterator<string> iterator = new ListyIterator<string>(createData.ToArray());

            while (true)
            {
                string input = Console.ReadLine();
                if (input != "END")
                {
                    switch (input)
                    {
                        case "Move":
                            Console.WriteLine(iterator.Move());
                            break;
                        case "Print":
                            iterator.Print();
                            break;
                        case "HasNext":
                            Console.WriteLine(iterator.HasNext());
                            break;
                        case "PrintAll":
                            foreach (var item in iterator)
                            {
                                Console.Write($"{item} ");
                            }
                            Console.WriteLine();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
