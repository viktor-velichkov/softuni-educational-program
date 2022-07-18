using System;
using System.Collections.Generic;
using System.Text;

namespace _09.PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            this.Name = name;
            this.NumberOfBadges = 0;
            this.PokemonCollection = new List<Pokemon>();
        }
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> PokemonCollection { get; set; }
    }
}
