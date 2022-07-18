using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            RandomList list = new RandomList();
            list.Add("viktor");
            list.Add("raya");
            list.Add("simeon");
            list.Add("chushka");
            Console.WriteLine(list.Count);
            Console.WriteLine(list.RandomString());
            Console.WriteLine(list.Count);
        }
    }
}
