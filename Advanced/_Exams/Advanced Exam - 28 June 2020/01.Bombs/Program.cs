using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombEffects = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Stack<int> bombCasings = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Dictionary<string, int> bombs = new Dictionary<string, int>();
            bombs.Add("Datura Bombs", 0);
            bombs.Add("Cherry Bombs", 0);
            bombs.Add("Smoke Decoy Bombs", 0);
            while (bombEffects.Count > 0 && bombCasings.Count > 0 && !PouchIsFilled(bombs))
            {
                int currEffect = bombEffects.Peek();
                int currCasing = bombCasings.Peek();
                if (currCasing+currEffect==40)
                {
                    bombs["Datura Bombs"]++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else if (currCasing + currEffect == 60)
                {
                    bombs["Cherry Bombs"]++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else if (currCasing + currEffect == 120)
                {
                    bombs["Smoke Decoy Bombs"]++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else
                {
                    bombCasings.Pop();
                    if (currCasing>5)
                    {
                        bombCasings.Push(currCasing - 5);
                    }
                    else
                    {
                        bombCasings.Push(0);
                    }
                    
                }
            }
            if (PouchIsFilled(bombs))
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (bombEffects.Count==0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {String.Join(", ",bombEffects)}");
            }
            if (bombCasings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {String.Join(", ", bombCasings)}");
            }
            foreach (var bomb in bombs.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
        static bool PouchIsFilled(Dictionary<string,int> pouch)
        {
            bool isFilled = true;
            var bombsCounts = pouch.Values.ToArray();
            foreach (var count in bombsCounts)
            {
                if (count<3)
                {
                    isFilled = false;
                }
            }
            return isFilled;
        }
    }
}
