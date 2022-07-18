using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace _03.Stack
{
    public class CustomStack<T>: IEnumerable<T>
    {
        int index;
        public CustomStack()
        {
            this.Collection = new List<T>();   
        }
        public List<T> Collection { get; set; }

        public void Push(params T[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                this.Collection.Add(elements[i]);
            }
        }
        public T Pop()
        {
            if (this.Collection.Count!=0)
            {
                T popped = this.Collection[this.Collection.Count - 1];
                this.Collection.RemoveAt(this.Collection.Count - 1);
                return popped;
            }
            else
            {
                Console.WriteLine("No elements");
                return default(T);
            }
            
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Collection.Count-1; i >= 0; i--)
            {
                yield return this.Collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
