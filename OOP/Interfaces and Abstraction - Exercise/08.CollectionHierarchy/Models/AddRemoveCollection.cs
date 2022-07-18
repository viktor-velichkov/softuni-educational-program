using _08.CollectionHierarchy.Contracts;

namespace _08.CollectionHierarchy.Models
{
    public class AddRemoveCollection : AddCollection, IAddRemoveCollection
    {
        public AddRemoveCollection() : base()
        {

        }

        public override int Add(string item)
        {
            if (this.Elements.Count < 100)
            {
                this.Elements.Insert(0, item);
            }
            return 0;
        }
        public virtual string Remove()
        {
            int indexTobeRemoved = this.Elements.Count - 1;
            string result = this.Elements[indexTobeRemoved];
            this.Elements.RemoveAt(indexTobeRemoved);
            return result;
        }
    }
}
