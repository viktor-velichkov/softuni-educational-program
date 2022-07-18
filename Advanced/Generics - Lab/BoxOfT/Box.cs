using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        public Box()
        {
            this.Stack = new Stack<T>();
        }
        public int Count { get { return this.Stack.Count; } }
        public Stack<T> Stack { get; set; }

        public void Add(T element)
        {
            this.Stack.Push(element);
        }
        public T Remove()
        {
            return this.Stack.Pop();
        }
    }
}
