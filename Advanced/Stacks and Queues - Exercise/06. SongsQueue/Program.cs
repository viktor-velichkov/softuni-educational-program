using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songList = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Queue<string> songsQueue = new Queue<string>(songList);
            while (songsQueue.Count>0)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                Queue<string> command = new Queue<string>(input);
                string action = command.Dequeue();
                switch (action)
                {
                    case "Play":
                        songsQueue.Dequeue();
                        break;
                    case "Add":
                        string currentSong = String.Join(" ",command);
                        if (!songsQueue.Contains(currentSong))
                        {
                            songsQueue.Enqueue(currentSong);
                        }
                        else
                        {
                            Console.WriteLine($"{currentSong} is already contained!");
                        }
                        break;
                    case "Show":
                        Console.WriteLine(String.Join(", ",songsQueue));
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
