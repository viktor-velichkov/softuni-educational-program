using System;
using System.Collections;
using System.Collections.Generic;

namespace _02.Collection
{
    public class ListyIterator<T> : IEnumerator<T>, IEnumerable<T>
    {
        int currentIndex = 0;
        public List<T> List { get; set; }
        public ListyIterator(params T[] array)
        {
            this.List = new List<T>(array);
        }

        public T Current => this.List[currentIndex];

        object IEnumerator.Current => this.List[currentIndex];

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (this.HasNext())
            {
                this.currentIndex++;
                return true;
            }
            else
            {
                return false;
            }

        }

        public void Reset()
        {
            currentIndex = -1;
        }

        public bool Move()
        {
            return this.MoveNext();
        }
        public bool HasNext()
        {
            if (this.List.Count != 0)
            {
                return this.currentIndex != this.List.Count - 1;
            }
            else
            {
                return false;
            }

        }
        public void Print()
        {
            try
            {
                Console.WriteLine(this.Current);
            }
            catch (Exception)
            {
                Exception exception = new Exception("Invalid Operation!");
                Console.WriteLine(exception.Message);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.List.Count; i++)
            {
                yield return this.List[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
