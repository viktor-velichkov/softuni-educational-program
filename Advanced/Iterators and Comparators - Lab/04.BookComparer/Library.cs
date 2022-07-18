using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {

        public Library(params Book[] books)
        {
            this.Books = new List<Book>(books);
            this.Books.Sort(new BookComparator());
        }
        public List<Book> Books { get; set; }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(this.Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }



        private class LibraryIterator : IEnumerator<Book>
        {
            int index;
            List<Book> books;
            public Book Current => books[index];

            object IEnumerator.Current => books[index];

            public LibraryIterator(List<Book> books)
            {
                this.books = books;
                this.index = -1;
            }
            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                this.index++;
                if (index >= books.Count)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            public void Reset()
            {
                index = -1;
            }
        }
    }
}
