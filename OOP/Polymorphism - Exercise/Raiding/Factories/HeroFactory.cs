using Raiding.Common;
using Raiding.Exceptions;
using Raiding.Models;

namespace Raiding.Factories
{
    public class HeroFactory
    {
        public HeroFactory()
        {

        }
        public BaseHero CreateHero(string heroType,string name)
        {
            switch (heroType)
            {
                case "Druid":
                    return new Druid(name);
                case "Paladin":
                    return new Paladin(name);
                case "Rogue":
                    return new Rogue(name);
                case "Warrior":
                    return new Warrior(name);
                default:
                    throw new InvalidHeroTypeException(ExceptionMessages.INVALID_HERO_TYPE_EXCEPTION_MESSAGE);
            }
        }
    }
}
