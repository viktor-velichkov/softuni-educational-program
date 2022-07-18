using System;
using System.Collections.Generic;
using System.Text;

namespace _04.GenericSwapMethodInteger
{
    public class Box<T>
    {
        public List<T> Values { get; set; }
        public Box(List<T> items)
        {
            this.Values = new List<T>();
            this.Values = items;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            T value = this.Values[firstIndex];
            this.Values[firstIndex] = this.Values[secondIndex];
            this.Values[secondIndex] = value;

        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this.Values)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }
            return sb.ToString();
        }
    }
}
