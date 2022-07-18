using System;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            int result = x.Title.CompareTo(y.Title);
            if (result!=0)
            {
                return result;
            }
            else
            {
                return x.Year.CompareTo(y.Year)*-1;
            }
        }
    }
}
