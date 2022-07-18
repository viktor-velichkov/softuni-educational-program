using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int seconds = int.Parse(Console.ReadLine());
            int initialSeconds = seconds;
            int freeWindow = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            bool ACrashHappened = false;
            int counter = 0;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                else if (input == "green")
                {
                    while (seconds > 0)
                    {
                        if (queue.Count > 0)
                        {
                            string nextCar = queue.Peek();
                            if (nextCar.Length <= seconds)
                            {
                                queue.Dequeue();
                                counter++;
                                seconds -= nextCar.Length;
                            }
                            else
                            {
                                if (nextCar.Length - seconds <= freeWindow)
                                {
                                    queue.Dequeue();
                                    counter++;
                                    seconds = 0;

                                }
                                else
                                {
                                    char[] nextCarLetters = nextCar.ToCharArray();
                                    Console.WriteLine("A crash happened!");
                                    Console.WriteLine($"{nextCar} was hit at {nextCarLetters[seconds + freeWindow]}.");
                                    ACrashHappened = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            seconds = initialSeconds;
                            break;
                        }
                    }
                    seconds = initialSeconds;
                }
                else
                {
                    queue.Enqueue(input);
                }
                if (ACrashHappened == true)
                {
                    break;
                }
            }
            if (!ACrashHappened)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{counter} total cars passed the crossroads.");
            }

        }
    }
}
