using _08.CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy.Models
{
    public class MyList : AddRemoveCollection, IMyList
    {
        public MyList() : base()
        {

        }
        public int Used { get { return this.Elements.Count; } }
        public override string Remove()
        {
            string result = this.Elements[0];
            this.Elements.RemoveAt(0);
            return result;
        }
    }
}
