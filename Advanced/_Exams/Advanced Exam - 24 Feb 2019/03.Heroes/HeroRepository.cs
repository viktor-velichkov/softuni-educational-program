using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        public int Count { get { return heroes.Count; } }
        Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();
        public void Add(Hero hero)
        {
            if (!heroes.ContainsKey(hero.Name))
            {
                heroes.Add(hero.Name, hero);
            }
        }
        public void Remove(string name)
        {
            if (heroes.ContainsKey(name))
            {
                heroes.Remove(name);
            }
        }
        public Hero GetHeroWithHighestStrength()
        {
            var strengths = heroes.Select(x => x.Value).Select(x=>x.Item.Strength).ToArray() ;
            int max = int.MinValue;
            int maxIndex = -1;
            for (int i = 0; i < strengths.Length; i++)
            {
                if (max<strengths[i])
                {
                    max = strengths[i];
                    maxIndex = i;
                }
            }
            string result = heroes.Select(x => x.Key).ToArray()[maxIndex];
            return heroes[heroes.Select(x => x.Key).ToArray()[maxIndex]];
        }
        public Hero GetHeroWithHighestAbility()
        {
            var abilities = heroes.Select(x => x.Value).Select(x => x.Item.Ability).ToArray();
            int max = int.MinValue;
            int maxIndex = -1;
            for (int i = 0; i < abilities.Length; i++)
            {
                if (max < abilities[i])
                {
                    max = abilities[i];
                    maxIndex = i;
                }
            }
            string result = heroes.Select(x => x.Key).ToArray()[maxIndex];
            return heroes[heroes.Select(x => x.Key).ToArray()[maxIndex]];
        }
        public Hero GetHeroWithHighestIntelligence()
        {
            var intelligence = heroes.Select(x => x.Value).Select(x => x.Item.Intelligence).ToArray();
            int max = int.MinValue;
            int maxIndex = -1;
            for (int i = 0; i < intelligence.Length; i++)
            {
                if (max < intelligence[i])
                {
                    max = intelligence[i];
                    maxIndex = i;
                }
            }
            return heroes[heroes.Select(x => x.Key).ToArray()[maxIndex]];
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var hero in heroes.Select(x=>x.Value))
            {
                sb.AppendLine(hero.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
