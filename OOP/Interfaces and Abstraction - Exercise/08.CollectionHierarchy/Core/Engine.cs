using _08.CollectionHierarchy.Contracts;
using _08.CollectionHierarchy.Models;
using System;
using System.Linq;
using System.Text;

namespace _08.CollectionHierarchy.Core
{
    public class Engine
    {
        public void Run()
        {
            AddCollection addColl = new AddCollection();
            AddRemoveCollection addRemColl = new AddRemoveCollection();
            MyList myList = new MyList();
            IAddCollection[] addCollections = new IAddCollection[3] { addColl, addRemColl, myList };
            IAddRemoveCollection[] addRemoveCollections = new IAddRemoveCollection[2] { addRemColl, myList };

            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            int removeOperationsCount = int.Parse(Console.ReadLine());
            foreach (var collection in addCollections)
            {
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < input.Length; i++)
                {
                    result.Append($"{collection.Add(input[i])} ");
                }
                Console.WriteLine(result.ToString());                
            }
            foreach (var collection in addRemoveCollections)
            {
                StringBuilder result = new StringBuilder();
                for (int i = 0; i < removeOperationsCount; i++)
                {
                    result.Append($"{collection.Remove()} ");
                }
                Console.WriteLine(result.ToString());
            }
        }        
    }
}
