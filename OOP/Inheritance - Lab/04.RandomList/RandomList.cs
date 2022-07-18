using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            int index = new Random().Next(0, this.Count - 1);
            string result = this[index];
            this.RemoveAt(index);
            return result;
        }
    }
}
