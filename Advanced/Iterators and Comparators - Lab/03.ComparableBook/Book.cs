using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = new List<string>();
            this.Authors = new List<string>(authors);
        }
        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Authors { get; set; }

        public int CompareTo(Book other)
        {
            if (this.Year < other.Year)
            {
                return -1;
            }
            else if (this.Year == other.Year)
            {
                if (this.Title[0] < other.Title[0])
                {
                    return -1;
                }
                else if (this.Title[0] == other.Title[0])
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 1;
            }
        }
        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}
