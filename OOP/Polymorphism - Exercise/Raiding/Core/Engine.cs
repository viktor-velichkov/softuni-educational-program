using Raiding.Core.Contracts;
using Raiding.Exceptions;
using Raiding.Factories;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        public Engine()
        {

        }
        public void Run()
        {
            List<BaseHero> heroes = new List<BaseHero>();
            HeroFactory heroFactory = new HeroFactory();
            int N = int.Parse(Console.ReadLine());

            while (heroes.Count < N)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                try
                {
                    heroes.Add(heroFactory.CreateHero(heroType, heroName));
                }
                catch (InvalidHeroTypeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            int bossPower = int.Parse(Console.ReadLine());
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }
            if (bossPower <= heroes.Select(x => x.Power).Sum())
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
