using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)

        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input != "Tournament")
                {
                    string[] line = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                    string trainerName = line[0];
                    string pokemonName = line[1];
                    string pokemonElement = line[2];
                    int pokemonHealth = int.Parse(line[3]);

                    Pokemon currPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                    if (!trainers.ContainsKey(trainerName))
                    {
                        trainers.Add(trainerName, new Trainer(trainerName));
                    }
                    trainers[trainerName].PokemonCollection.Add(currPokemon);
                }
                else
                {
                    break;
                }
            }
            while (true)
            {
                string command = Console.ReadLine();
                if (command != "End")
                {
                    foreach(var trainer in trainers.Values)
                    {
                        if (trainer.PokemonCollection.Select(x => x.Element).ToArray().Contains(command))
                        {
                            trainer.NumberOfBadges++;
                        }
                        else
                        {
                            for (int i=0; i< trainer.PokemonCollection.Count;i++)
                            {
                                if (trainer.PokemonCollection[i].Health>10)
                                {
                                    trainer.PokemonCollection[i].Health -= 10;
                                }
                                else
                                {
                                    trainer.PokemonCollection.RemoveAt(i--);
                                }                                
                            }
                        }
                        
                    }
                }
                else
                {
                    foreach (var trainer in trainers.OrderByDescending(x=>x.Value.NumberOfBadges))
                    {
                        Console.WriteLine($"{trainer.Key} {trainer.Value.NumberOfBadges} {trainer.Value.PokemonCollection.Count}");
                    }
                    break;
                }
            }
        }
    }
}
