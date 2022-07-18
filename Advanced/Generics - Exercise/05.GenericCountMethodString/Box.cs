using System;
using System.Collections.Generic;
using System.Text;

namespace _05.GenericCountMethodString
{
    public class Box<T> where T: IComparable
    {
        public List<T> Values { get; set; }
        public Box(List<T> items)
        {
            this.Values = new List<T>();
            this.Values = items;
        }
        
        public int CountOfElementInlist(T element)
        {
            int counter = 0;
            foreach (var item in this.Values)
            {
                if (item.CompareTo(element)>0)
                {
                    counter++;
                }
            }
            return counter;
        }
        
    }
}
