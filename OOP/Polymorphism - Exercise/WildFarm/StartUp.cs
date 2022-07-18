using WildFarm.Core;
using WildFarm.Core.Contracts;
using WildFarm.Factories;
using WildFarm.IO;

namespace WildFarm
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ConsoleReader reader = new ConsoleReader();
            ConsoleWriter writer = new ConsoleWriter();
            AnimalFactory animalFactory = new AnimalFactory();
            FoodFactory foodFactory = new FoodFactory();
            IEngine engine = new Engine(reader, writer,animalFactory,foodFactory);
            engine.Run();
        }
    }
}
