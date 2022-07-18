using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        Dictionary<string, Rabbit> rabbits = new Dictionary<string, Rabbit>();
        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return this.rabbits.Count; } }

        public void Add(Rabbit rabbit)
        {
            if (!rabbits.ContainsKey(rabbit.Name) && this.Count < this.Capacity)
            {
                rabbits.Add(rabbit.Name, rabbit);
                rabbit.Available = true;
            }
        }
        public bool RemoveRabbit(string name)
        {
            return rabbits.Remove(name);
        }
        public void RemoveSpecies(string species)
        {
            var rabbitsToRemove = rabbits.Where(x => x.Value.Species == species).Select(x => x.Value);
            foreach (var rabbit in rabbitsToRemove)
            {
                rabbits.Remove(rabbit.Name);
            }
        }
        public Rabbit SellRabbit(string name)
        {
            rabbits[name].Available = false;
            return rabbits[name];
        }
        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var rabbitsToSell = rabbits.Where(x => x.Value.Species == species).Select(x => x.Value).ToArray();
            foreach (var rabbit in rabbitsToSell)
            {
                rabbit.Available = false;
            }
            return rabbitsToSell;
        }
        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"Rabbits available at {this.Name}:");
            var availableRabbits = rabbits.Where(x => x.Value.Available == true).Select(x=>x.Value);
            foreach (var rabbit in availableRabbits)
            {
                report.AppendLine(rabbit.ToString());
            }
            return report.ToString().Trim();
        }

    }
}
