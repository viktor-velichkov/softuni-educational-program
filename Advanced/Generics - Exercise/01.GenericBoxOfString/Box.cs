using System;
using System.Collections.Generic;
using System.Text;

namespace _01.GenericBoxOfString
{
    public class Box<T>
    {
        T value;
        public Box(T item)
        {
            this.value = item;
        }
        public override string ToString()
        {
            return $"{this.value.GetType()}: {this.value}";
        }
    }
}
