using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        public Lake(params int[] array)
        {
            this.StoneNumbers = array;
        }
        public int[] StoneNumbers { get; set; }
        public IEnumerator<int> GetEnumerator()
        {
            return new LakeIterator(this.StoneNumbers);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
