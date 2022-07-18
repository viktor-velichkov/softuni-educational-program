using _08.CollectionHierarchy.Contracts;
using System.Collections.Generic;

namespace _08.CollectionHierarchy.Models
{
    public class AddCollection : IAddCollection
    {
        private List<string> elements;
        public AddCollection()
        {
            this.Elements = new List<string>();
        }
        public List<string> Elements { get { return this.elements; } set { this.elements = value; } }

        public virtual int Add(string item)
        {
            if (this.Elements.Count<100)
            {
                this.Elements.Add(item);
            }
            
            return this.Elements.Count-1;
        }
    }
}
