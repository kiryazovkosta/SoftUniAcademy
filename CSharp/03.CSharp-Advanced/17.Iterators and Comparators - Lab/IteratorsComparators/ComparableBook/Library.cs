namespace IteratorsAndComparators
{
    using System.Collections;
    using System.Collections.Generic;

    public class Library : IEnumerable<Book>
    {
        private SortedSet<Book> books;

        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            //return new LibraryIterator(this.books);
            foreach (var book in this.books)
            {
                yield return book;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;
            private int index;

            public LibraryIterator(List<Book> books)
            {
                this.Reset();
                this.books = books;
            }

            public Book Current => this.books[this.index];

            public bool MoveNext()
            {
                this.index++;
                return this.index < this.books.Count;
            }

            public void Reset()
            {
                this.index = -1;
            }

            object IEnumerator.Current => this.Current;

            public void Dispose()
            {
            }
        }
    }
}
